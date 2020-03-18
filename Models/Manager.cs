
using System.ComponentModel.DataAnnotations;  

namespace Csharp  
{  
    public class Manager  
    {  
        [Required]
        public int ID { get; set; }  
        [Required]  
        public string Name { get; set; }  
        [Required]          
        public string Department { get; set; }

        
            
         
      
    }  
}