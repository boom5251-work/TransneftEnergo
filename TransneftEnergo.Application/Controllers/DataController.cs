using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransneftEnergo.DataAccess.Context;
using TransneftEnergo.DataAccess.Models;
using TransneftEnergo.DataAccess.ViewModel;

namespace TransneftEnergo.Application.Controllers
{
    /// <summary>
    /// Контроллер данных.
    /// </summary>
    [ApiController]
    [ApiVersionNeutral]
    [Route("api")]
    public class DataController : ControllerBase
    {
        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger<DataController> _logger;

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private readonly IDatabaseContext _context;



        /// <summary>
        /// Параметризированный конструктор.
        /// </summary>
        /// <param name="logger">Логгер.</param>
        /// <param name="context">Контекст базы данных.</param>
        public DataController(ILogger<DataController> logger, IDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }



        /// <summary>
        /// Задача 1: Обрабатывает запрос на создание новой точки измерения с указанием счетчика, трансформатора тока и трансформатора напряжения.
        /// </summary>
        /// <param name="viewModel">Модель представления точки измерения.</param>
        /// <returns>Результата действия.</returns>
        [HttpPost("task1")]
        public async Task<IActionResult> PostNewMeasuringPointAsync(MeasuringPointViewModel viewModel)
        {
            try
            {
                var measuringPoint = (MeasuringPoint)viewModel;

                _context.MeasuringPoints.Add(measuringPoint);
                _ = await _context.SaveChangesAsync();

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.LogError("{type} occurred while processing request.", ex.GetType());
                return StatusCode(500, new { Type = ex.GetType(), ex.Message });
            }
        }


        /// <summary>
        /// Задача 2: Обрабатывает запрос на выборку всех расчетных приборов учета в 2018 году.
        /// </summary>
        /// <returns>Результат действия.</returns>
        [HttpGet("task2")]
        public async Task<IActionResult> GetAccountingDevicesAsync()
        {
            try
            {
                var accountingDevices = await _context.AccountingDevices
                    .Include(accountingDevice => accountingDevice.MeasuringPoints)
                    .Include(accountingDevice => accountingDevice.SupplyPoint)
                    .Join(_context.MeasuringPointAccountingDevices, ad => ad.Id, b => b.AccountingDeviceId, (ad, b) => new { AccountingDevice = ad, Binding = b })
                    .Where(join => join.Binding.FromDate.Year <= 2018 && join.Binding.ToDate.Year >= 2018)
                    .Select(join => new
                    {
                        join.AccountingDevice.Id,
                        join.AccountingDevice.SupplyPointId,
                        join.Binding.FromDate,
                        join.Binding.ToDate
                    })
                    .ToListAsync();

                return Ok(accountingDevices);
            }
            catch (Exception ex)
            {
                _logger.LogError("{type} occurred while processing request.", ex.GetType());
                return StatusCode(500, new { Type = ex.GetType(), ex.Message });
            }
        }


        /// <summary>
        /// Задача 3: Обрабатывает запрос на выборку всех счетчиков с закончившимся сроком поверки по указанному объекту потребления.
        /// </summary>
        /// <param name="consumptionObjectId">Уникальный идентификатор объекта потребления.</param>
        /// <returns>Результат действия со списком счетчиков электроэнергии.</returns>
        [HttpGet("task3/{consumptionObjectId:int}")]
        public async Task<IActionResult> GetExpiredEnergyMetersAsync(int consumptionObjectId)
        {
            try
            {
                var energyMeters = await _context.MeasuringPoints
                    .Where(measuringPoint => measuringPoint.ConsumptionObjectId == consumptionObjectId)
                    .Include(measuringPoint => measuringPoint.EnergyMeter)
                    .Where(measuringPoint => measuringPoint.EnergyMeter.VerificationDate > DateTime.UtcNow)
                    .Select(measuringPoint => measuringPoint.EnergyMeter)
                    .ToListAsync();

                return Ok(energyMeters);
            }
            catch (Exception ex)
            {
                _logger.LogError("{type} occurred while processing request.", ex.GetType());
                return StatusCode(500, new { Type = ex.GetType(), ex.Message });
            }
        }


        /// <summary>
        /// Задача 4: Обрабатывает запрос на выборку всех трансформаторов напряжения с закончившимся сроком поверки по указанному объекту потребления.
        /// </summary>
        /// <param name="consumptionObjectId">Уникальный идентификатор объекта потребления.</param>
        /// <returns>Результат действия со списком трансформаторов напряжения.</returns>
        [HttpGet("task4/{consumptionObjectId:int}")]
        public async Task<IActionResult> GetExpiredVoltageTransformersAsync(int consumptionObjectId)
        {
            try
            {
                var currentTransformers = await _context.MeasuringPoints
                    .Where(measuringPoint => measuringPoint.ConsumptionObjectId == consumptionObjectId)
                    .Include(measuringPoint => measuringPoint.VoltageTransformer)
                    .Where(measuringPoint => measuringPoint.VoltageTransformer.VerificationDate > DateTime.UtcNow)
                    .Select(measuringPoint => measuringPoint.VoltageTransformer)
                    .ToListAsync();

                return Ok(currentTransformers);
            }
            catch (Exception ex)
            {
                _logger.LogError("{type} occurred while processing request.", ex.GetType());
                return StatusCode(500, new { Type = ex.GetType(), ex.Message });
            }
        }


        /// <summary>
        /// Задача 3: Обрабатывает запрос на выборку всех трансформаторов тока с закончившимся сроком поверки по указанному объекту потребления.
        /// </summary>
        /// <param name="consumptionObjectId">Уникальный идентификатор объекта потребления.</param>
        /// <returns>Результат действия со списком трансформаторов тока.</returns>
        [HttpGet("task5/{consumptionObjectId:int}")]
        public async Task<IActionResult> GetExpiredCurrentTransformersAsync(int consumptionObjectId)
        {
            try
            {
                var currentTransformers = await _context.MeasuringPoints
                    .Where(measuringPoint => measuringPoint.ConsumptionObjectId == consumptionObjectId)
                    .Include(measuringPoint => measuringPoint.CurrentTransformer)
                    .Where(measuringPoint => measuringPoint.CurrentTransformer.VerificationDate > DateTime.UtcNow)
                    .Select(measuringPoint => measuringPoint.CurrentTransformer)
                    .ToListAsync();

                return Ok(currentTransformers);
            }
            catch (Exception ex)
            {
                _logger.LogError("{type} occurred while processing request.", ex.GetType());
                return StatusCode(500, new { Type = ex.GetType(), ex.Message });
            }
        }
    }
}