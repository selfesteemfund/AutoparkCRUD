using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autopark.Models
{
    [DisplayName("Техосмотры")]
    public class Inspection
    {
        [DisplayName("Номер техосмотра")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Номер автомобиля")]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Замечания")]
        [StringLength(500)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string InspNote { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата техосмотра")]
        [DisplayFormat(DataFormatString = @"{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InspDate { get; set; }
        public Car Car { get; set; }
        

    }
}
