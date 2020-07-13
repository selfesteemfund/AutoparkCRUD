using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autopark.Models
{
    [DisplayName("Автомобили")]
    public class Car
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле, не более 50-ти символов")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Display(Name = "Модель автомобиля")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DisplayFormat(DataFormatString = @"{0:yyyy\/dd\/MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата выпуска")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "ГРЗ автомобиля")]
        [StringLength(9, MinimumLength = 6)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string CarNumber { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата постановки на учёт")]
        [DisplayFormat(DataFormatString = @"{0:yyyy\/dd\/MM}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }

        public string InspCarId
        {
            get
            {
                return Id + " - " + CarNumber;
            }
        }

        public ICollection<Inspection> Inspections { get; set; }
    }

}
