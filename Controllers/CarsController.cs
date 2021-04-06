using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregsListButInC_.db;
using gregsListButInC_.Models;


namespace gregsListButInC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
    [HttpGet]
       public ActionResult<IEnumerable<Car>> Get(){
            try {
                return Ok(FakeDB.Cars);
        } catch (System.Exception err){
                return BadRequest(err.Message);
            }    
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar){
            try{
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            } catch (System.Exception err){
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId){
            try{
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if(carFound == null){
                    throw new System.Exception("That Car Doesn't Exist");
                }
                return Ok(carFound);
            } catch (System.Exception err){
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCar(string id){
            try{
                Car targetCar = FakeDB.Cars.Find(c => c.Id == id);
                if(FakeDB.Cars.Remove(targetCar)){
                    return Ok("Car Deleted");
                }else{
                    throw new System.Exception("That Car Ain't Real");
                }
            } catch (System.Exception err){
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar([FromBody] Car editedCar, string id){
            try{
                Car targetCar = FakeDB.Cars.Find(c => c.Id == id);
                if(targetCar == null){
                    throw new System.Exception("That Car Don't Exist");
                } else{
                    targetCar.Make = editedCar.Make;
                    targetCar.Model = editedCar.Model;
                    targetCar.ImgUrl = editedCar.ImgUrl;
                    targetCar.Price = editedCar.Price;
                    targetCar.Year = editedCar.Year;
                    targetCar.Description = editedCar.Description;
                    return targetCar;
                }
            } catch(System.Exception err){
                return BadRequest(err.Message);
            }
        }
    }
}