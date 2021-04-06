using System;
using System.ComponentModel.DataAnnotations;

namespace gregsListButInC_.Models
{
    public class Car
    {
     public Car(string make, string model, int price, int year, string imgUrl, string description){
         Make = make;
         Model = model;
         Price = price;
         Year = year;
         ImgUrl = imgUrl;
         Description = description;
    } 
    [Required]
    [MinLength(3)]
    public string Make {get; set;}  
    public string Model{get; set;}
    public int Price{get; set;}    
    public int Year{get; set;}
    public string ImgUrl{get; set;}
    [MaxLength(200)]
    public string Description{get; set;}
    public string Id { get; private set; } = Guid.NewGuid().ToString();
}
}