using System;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace GestUAB.Models
{
    /// <summary>
    /// Course class
    /// </summary>
    /// 
    public class Course : IModel
    {
        #region Builder
        
        /// <summary>
        /// Class builder
        /// </summary>
        public Course ()
        {

        }

        /// <summary>
        /// Static method that creates a default course.
        /// </summary>
        /// <returns>Default course</returns>
        /// 
        public static Course DefaultCourse()
        {
            return new Course() { 
                Id = Guid.NewGuid(),
                Name = string.Empty
            };
        }

        #endregion

        #region IModel implementation
        [Display(Name = "Código",
                 Description= "Código do curso.")]
        [ScaffoldVisibility(all:ScaffoldVisibilityType.Hidden)] 
        public System.Guid Id { get ; set ; }
        #endregion
        
        #region Variables
        [Display(Name = "Nome",
                 Description= "Nome do curso. Ex.: Matemática.")]
        [ScaffoldVisibility(all:ScaffoldVisibilityType.Show)] 
        public string Name { get; set; }

        [Display(Name = "Ativo",
                 Description= "O curso está ativo?")]
        [ScaffoldVisibility(all:ScaffoldVisibilityType.Show)] 
        public bool Active { get; set; }
        #endregion

    }

    /// <summary>
    /// Course Validator Class
    /// </summary>
    /// 
    public class CourseValidator: ValidatorBase<Course>
    {
        /// <summary>
        /// Method that validates when the object will be created or changed
        /// </summary>
        /// 
        public CourseValidator ()
        {
            RuleFor (course => course.Id).NotEmpty ();

            RuleSet ("Update", () => {
                RuleFor (user => user.Name)
                    .NotEmpty ().WithMessage ("O campo nome é obrigatório.")
                    .Matches (@"^[a-zA-Z\u00C0-\u00ff\s]*$").WithMessage ("Insira somente letras.")
                        .Length (2, 30).WithMessage ("O nome deve conter entre 2 e 30 caracteres.");
            }
            );
        }
    }
}
