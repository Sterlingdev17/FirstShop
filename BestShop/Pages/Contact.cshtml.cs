using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BestShop.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        [Required(ErrorMessage = "The First Name is required")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "The Last Name is required")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "The Email is required")]
        [Display(Name = "Email*")]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Phone { get; set; } = "";

        [BindProperty, Required]
        [Display(Name = "Subject*")]
        public string Subject { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "The Message is required")]
        [MinLength(5, ErrorMessage = "the message should be at least 5 character")]
        [MaxLength(1024, ErrorMessage = "the message should be at less than 1024 characters")]
        [Display(Name = "Message*")]
        public string Message { get; set; } = "";
        public List<SelectListItem> SubjectList { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Order Status", Text = "Order Status"},
            new SelectListItem {Value = "Refun Request", Text = "Refund Request"},
            new SelectListItem {Value = "Job Application", Text = "Job Application"},
            new SelectListItem {Value = "Orther", Text = "Orther"},

        };




        //message if success or errors

        public string SuccessMessage { get; set; } = "";
        public string ErrorMessage { get; set; } = "";

        public void OnPost()
        {
          
            // check if required field is empty
            if (!ModelState.IsValid) 
            {
                ErrorMessage = "please fill all required fields";
                return;
            }

            if (Phone == null) Phone = "";

            // add data to the database


            // send confirmation email to the client
            SuccessMessage = "We have recieve your message";


            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Subject = "";
            Message = "";

            ModelState.Clear();
        }
    }
}
