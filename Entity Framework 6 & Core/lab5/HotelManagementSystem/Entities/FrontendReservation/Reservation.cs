using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Entities.FrontendReservation;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string BirthDay { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Gender { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string EmailAddress { get; set; } = null!;

    public int NumberGuest { get; set; }

    [Required]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string AptSuite { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string State { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string ZipCode { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string RoomType { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string RoomFloor { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string RoomNumber { get; set; } = null!;

    public double TotalBill { get; set; }

    [Required]
    [StringLength(10)]
    public string PaymentType { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string CardType { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CardNumber { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CardExp { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string CardCvc { get; set; } = null!;

    public DateOnly ArrivalTime { get; set; }

    public DateOnly LeavingTime { get; set; }

    public bool CheckIn { get; set; }

    public int BreakFast { get; set; }

    public int Lunch { get; set; }

    public int Dinner { get; set; }

    public bool Cleaning { get; set; }

    public bool Towel { get; set; }

    public bool SSurprise { get; set; }

    public bool SupplyStatus { get; set; }

    public int FoodBill { get; set; }
}