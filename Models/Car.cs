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
        [Required(ErrorMessage = "Обязательное поле.")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Марка")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DisplayFormat(DataFormatString = @"{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата выпуска (д/м/г)")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "ГРЗ")]
        //[StringLength(9, MinimumLength = 6)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string CarNumber { get; set; }
        [Required(ErrorMessage = "Обязательное поле.")]
        [Display(Name = "Дата учёта (д/м/г)")]
        [DisplayFormat(DataFormatString = @"{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
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
/*-
 
<div class="form-group">
<label class="control-label">CarId</label>
<input id="CarId" name="CarId" value="@(ViewBag.CarId)" class="form-control" disabled />
</div>

                    
min="01-01-1995" max="12-31-2020"

    
-*/
