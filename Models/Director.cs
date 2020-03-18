using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp.Models;
namespace Csharp
{ 
  public class Director  
  {  
    public int ID { get; set; }  
          
    public string Name { get; set; }    
          
    public string Department { get; set; }  
           
  }  
}