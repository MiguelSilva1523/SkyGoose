using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; // MySQL library
using Microsoft.AspNetCore.Mvc;

namespace SkyGooseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly string connectionString = "Server=localhost;Database=skygoose;User=root;"

        // Endpoint for handling contact form submissions
        [HttpPost("contato")]
        public IActionResult SubmitContact([FromForm] string Nome, [FromForm] string Email, [FromForm] string Mensagem)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Contato (Name, Email, Messagem) VALUES (@Name, @Email, @Message);";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", Nome);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Message", Mensagem);
                        command.ExecuteNonQuery();
                    }
                }
                return Ok("Mensagem enviada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Endpoint for retrieving jet service data
        [HttpGet("jatos")]
        public IActionResult GetJetServices()
        {
            try
            {
                var jetList = new List<object>();

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Model, Capacity, PricePerHour FROM servicos;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                jetList.Add(new
                                {
                                    Model = reader.GetString("Model"),
                                    Capacity = reader.GetInt32("Capacity"),
                                    PricePerHour = reader.GetDecimal("PricePerHour")
                                });
                            }
                        }
                    }
                }

                return Ok(jetList);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}