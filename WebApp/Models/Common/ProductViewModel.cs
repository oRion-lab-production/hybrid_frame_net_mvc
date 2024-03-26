using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Tools.Entities.Components;

namespace WebApp.Models.Common
{
    public class ProductIndexViewModel
    {
        [Display(Name = "Name")]
        public string Name_filter { get; set; }
        [Display(Name = "Price")]
        [DataType(DataType.Text)]
        public double? Price_filter { get; set; }
        [Display(Name = "Quantity")]
        [DataType(DataType.Text)]
        public int? Quantity_filter { get; set;}
    }

    public class DT_productViewDtoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public DT_productViewDtoModel() { }
    }

    public class DT_productViewModel : DataTable_viewBaseModel
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Price")]
        public string Price { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("IsActive")]
        public string IsActive { get; set; }
    }

    public class ProductAddViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price cannot be empty.")]
        public double Price { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity cannot be empty.")]
        public int Quantity { get; set; }
    }

    public class ProductUpdateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price cannot be empty.")]
        public double Price { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity cannot be empty.")]
        public int Quantity { get; set; }
    }
}
