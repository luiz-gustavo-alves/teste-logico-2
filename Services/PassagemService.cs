using testeLogicoBTI.DTOs;
using testeLogicoBTI.Exceptions;
using testeLogicoBTI.Models;
using testeLogicoBTI.Repositories;

namespace testeLogicoBTI.Services;

public class PassagemService(
  CondutorRepository condutorRepository,
  PedagioRepository pedagioRepository,
  PassagemRepository passagemRepository
)
{
  private readonly CondutorRepository _condutorRepository = condutorRepository;
  private readonly PedagioRepository _pedagioRepository = pedagioRepository;
  private readonly PassagemRepository _passagemRepository = passagemRepository;

  private readonly int DISCOUNT_COUNTER = 10;
  private readonly double DISCOUNT_LIMIT = 0.20;
  private readonly double INITIAL_DISCOUNT = 0.05;

  private async Task<Passagem> CreatePassagem(AtualizarPassagemDTO dto)
  {
    Passagem newPassagem = new()
    {
      CondutorId = dto.CondutorId,
      PedagioId = dto.PedagioId
    };
    Passagem passagem = await _passagemRepository.CreateAsync(newPassagem);
    return passagem;
  }

  private async Task HandleCounter(Passagem passagem)
  {
    DateTime currentDate = DateTime.Now;
    int currentMonth = currentDate.Month;
    int currentYear = currentDate.Year;

    if (passagem.MesAtual.Equals(currentMonth) && passagem.AnoAtual.Equals(currentYear))
    {
      passagem.Contador++;
    }
    else
    {
      passagem.Contador = 1;
      passagem.MesAtual = currentMonth;
      passagem.AnoAtual = currentYear;
    }
    await _passagemRepository.Update(passagem);
  }

  private int HandleDiscount(Pedagio pedagio, Passagem passagem)
  {
    double discount = INITIAL_DISCOUNT * (passagem.Contador / DISCOUNT_COUNTER);
    if (discount.Equals(0))
      return pedagio.Preco;

    int priceWithDiscount;
    if (discount < DISCOUNT_LIMIT)
    {
      discount = (100 - (discount * 100)) / 100;
      priceWithDiscount = (int)Math.Floor(pedagio.Preco * discount);
    }
    else
    {
      discount = (100 - (DISCOUNT_LIMIT * 100)) / 100;
      priceWithDiscount = (int)Math.Floor(pedagio.Preco * discount);
    }
    return priceWithDiscount;
  }

  public async Task<OutputAtualizarPassagemDTO> UpdatePassagem(AtualizarPassagemDTO dto)
  {
    Condutor? condutor = await _condutorRepository.GetById(dto.CondutorId);
    if (condutor is null)
      throw new NotFoundException("Condutor não encontrado");

    Pedagio? pedagio = await _pedagioRepository.GetById(dto.PedagioId);
    if (pedagio is null)
      throw new NotFoundException("Pedágio não encontrado");

    OutputAtualizarPassagemDTO outputDTO;
    Passagem? passagem = await _passagemRepository.GetByCondutorAndPedagioIds(dto.CondutorId, dto.PedagioId);
    if (passagem is null)
    {
      passagem = await CreatePassagem(dto);
      outputDTO = new()
      {
        CondutorId = dto.CondutorId,
        PedagioId = dto.PedagioId,
        Preco = pedagio.Preco,
        UpdatedAt = passagem.UpdatedAt,
      };
    }
    else
    {
      await HandleCounter(passagem);
      int priceWithDiscount = HandleDiscount(pedagio, passagem);
      outputDTO = new()
      {
        CondutorId = dto.CondutorId,
        PedagioId = dto.PedagioId,
        Preco = priceWithDiscount,
        UpdatedAt = passagem.UpdatedAt,
      };
    }
    return outputDTO;
  }

  public async Task<Passagem> GetPassagemById(Guid id) 
  {
    Passagem? passagem = await _passagemRepository.GetById(id);
    if (passagem is null)
      throw new NotFoundException("Passagem não encontrada");

    return passagem;
  }
}