  
using System.ComponentModel.DataAnnotations;  

namespace Csharp  
{  
    public class Employee  
    {  
        public int ID { get; set; }  
        [Required]  
        public string Name { get; set; }  
 
        [Required]  
        public string Department { get; set; }  
       
    }  
}