using Microsoft.AspNetCore.Mvc;
using todoapi.Models;
using System.Collections.Generic;

namespace todoapi.Dependencies
{
    public interface ICharacter
    {
        Character GetCharacter();

        List<Character> GetCharacterList();
        
    }
}
