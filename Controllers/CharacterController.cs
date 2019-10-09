

using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using todoapi.Dependencies;
using todoapi.Models;
using System.Data.SqlClient;

namespace todoapi.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : ICharacter
    {

        List<Character> listOfCharacters => new List<Character>
        {
            new Character{
                Name = "Homero J. Simpson", 
                Gender = "Masculino", 
                Age = 36, 
                Description = "Esposo de Marge y padre de Bart, Lisa y Maggie Simpson.",
                Photo = "http://static.t13.cl/images/sizes/1200x675/1455720735-19-homer.jpg"         
            },
            new Character{
                Name = "Margory Simpson", 
                Gender = "Femenino", 
                Age = 36, 
                Description = "Esposa de Homero, Madre de la familia Simpson.",
                Photo = "http://pluspng.com/img-png/marge-simpson-hd-png-marge-simpson-2-png-1220.png"         
            },
            new Character{
                Name = "Bart Simpson", 
                Gender = "Masculino", 
                Age = 10, 
                Description = "Hermano de Lisa y Maggie Simpson.",
                Photo = "https://upload.wikimedia.org/wikipedia/en/a/aa/Bart_Simpson_200px.png"         
            },
            new Character{
                Name = "Lisa Simpson", 
                Gender = "Femenino", 
                Age = 9, 
                Description = "Hermana de Bart y Maggie Simpsons.",
                Photo = "https://upload.wikimedia.org/wikipedia/en/thumb/e/ec/Lisa_Simpson.png/220px-Lisa_Simpson.png"         
            },
            new Character{
                Name = "Maggie Simpson", 
                Gender = "Femenino", 
                Age = 2, 
                Description = "Hermana de Bart y Lisa Simpson.",
                Photo = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9d/Maggie_Simpson.png/220px-Maggie_Simpson.png"         
            },
        };

        [HttpGet("{id}")]
        public Character GetCharacter(int id) 
        {
            Character tbl_characters = new Character();
            string connectionString = "data source=JESUSPC;initial catalog=db_simpsons;user id=simpsons;password=1234";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select * from vw_characters where id = {id}", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                try
                {
                    tbl_characters = new Character{
                        Id = reader.GetInt64(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")), 
                        Gender = reader.GetString(reader.GetOrdinal("gender")), 
                        Age = reader.GetInt32(reader.GetOrdinal("age")), 
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Photo = reader.GetString(reader.GetOrdinal("photo"))         
                    };
                }
                catch(System.ArgumentOutOfRangeException e)
                {
                    throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
                }
            }
             return tbl_characters;

        }

        [HttpGet]
        public List<Character> GetCharacterList() 
        {
            List<Character> tbl_characters = new List<Character>();
            string connectionString = "data source=JESUSPC;initial catalog=db_simpsons;user id=simpsons;password=1234";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from vw_characters", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Character character = new Character{
                    Id = reader.GetInt64(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")), 
                    Gender = reader.GetString(reader.GetOrdinal("gender")), 
                    Age = reader.GetInt32(reader.GetOrdinal("age")), 
                    Description = reader.GetString(reader.GetOrdinal("description")),
                    Photo = reader.GetString(reader.GetOrdinal("photo"))         
                };
                tbl_characters.Add(character);
            }
            conn.Close();
            return tbl_characters;
        }
    }
}