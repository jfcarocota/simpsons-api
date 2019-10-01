

using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using todoapi.Dependencies;
using todoapi.Models;

namespace todoapi.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : ICharacter
    {
        [HttpGet("{id}")]
        public Character GetCharacter() => new Character 
        {
             Name = "Homero J. Simpson", 
             Gender = "Masculino", 
             Age = 47, 
             Description = "Esposo de Marge y padre de Bart, Lisa y Maggie Simpson." 
        };

        [HttpGet]
        public List<Character> GetCharacterList() => new List<Character>
        {
            new Character{
                Name = "Homero J. Simpson", 
                Gender = "Masculino", 
                Age = 36, 
                Description = "Esposo de Marge y padre de Bart, Lisa y Maggie Simpson."         
            },
            new Character{
                Name = "Margory Simpson", 
                Gender = "Femenino", 
                Age = 36, 
                Description = "Esposa de Homero, Madre de la familia Simpson."         
            },
            new Character{
                Name = "Bart Simpson", 
                Gender = "Masculino", 
                Age = 10, 
                Description = "Hermano de Lisa y Maggie Simpson."         
            },
            new Character{
                Name = "Lisa Simpson", 
                Gender = "Femenino", 
                Age = 9, 
                Description = "Hermana de Bart y Maggie Simpsons."         
            },
            new Character{
                Name = "Maggie Simpson", 
                Gender = "Femenino", 
                Age = 2, 
                Description = "Hermana de Bart y Lisa Simpson."         
            },
        };
    }
}