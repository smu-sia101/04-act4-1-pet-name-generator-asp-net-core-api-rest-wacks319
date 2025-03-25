using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
namespace Act4_1PetName.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PetNameContoller : ControllerBase
    {


        [HttpPost("/generate")]
        public IActionResult Post([FromQuery] AnimalType animalType, bool hasLastName)
        {
            try
            { 
            string firstName = "";
            string lastName = "";
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, 4);
            if (animalType == AnimalType.Dog)
            {
                firstName = Names.Dog.First[randomIndex];
                if (hasLastName)
                {
                    randomIndex = rnd.Next(0, 4);
                    lastName = Names.Bird.Last[randomIndex];
                }

            }
            else
            {
                return BadRequest();
            }
            return Ok(string.Concat(firstName, lastName));
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }
    }

}