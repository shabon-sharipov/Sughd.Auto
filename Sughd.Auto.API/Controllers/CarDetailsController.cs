// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Sughd.Auto.Application.Constants;
// using Sughd.Auto.Domain.Models;
//
// namespace Sughd.Auto.API.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class CarDetailsController : ControllerBase
// {
//     public CarDetailsController()
//     {
//     }
//
//     [HttpGet("GetAll")]
//     public async Task<IActionResult> GetAll()
//     {
//         var carBody = new List<string>()
//         {
//             "Седан",
//             "Хэтчбек",
//             "Универсал",
//             "Внедорожник",
//             "Кроссовер",
//             "Пикап",
//             "Седан",
//             "Минивен",
//             "Фургон",
//             "Кабриолет",
//             "Купе",
//             "Лифтбэк"
//         };
//
//         var fuelTypes = new List<string>()
//         {
//             "Бензин",
//             "Бензин + газ",
//             "Газ",
//             "Дизель",
//             "Электричество",
//             "Гибрид",
//             "Другой",
//         };
//
//         var transmission = new List<string>()
//         {
//             "Механика",
//             "Автомат",
//             "Робот",
//         };
//
//         var dic = new Dictionary<string, object>()
//         {
//             { nameof(Car.CarBody), carBody },
//             { nameof(Car.FuelType), fuelTypes },
//             { nameof(Car.Transmission), transmission }
//         };
//
//         return Ok(dic);
//     }
// }