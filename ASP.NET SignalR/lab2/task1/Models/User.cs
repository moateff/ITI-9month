using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace task1.Models;

public class User : IdentityUser<Guid> { }