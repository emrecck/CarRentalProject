using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string CarDescriptionInvalid = "Car Description Invalid";
        public static string DailyPriceInvalid = "Daily Price must be bigger than zero";
        public static string MaintenanceTime = "Maintenance Time,Sorry";
        public static string GetCarDetails = "Here you are Car Details";
        public static string CarNotDelivered = "Uups! Sorry, Car is not delivered yet";
        public static string CarisRented= "Car is rented";
        public static string CustomerAdded = "Customer is Added";
        public static string UserAdded = "User is Added";
        public static string ColorAdded = "Color is added";
        public static string ColorDeleted = "Color is deleted succesefully";
        public static string ColorUpdated = "Color is updated";
        public static string CustomerDeleted = "Customer is deleted succesfully";
        public static string CarImageAdded = "Image is added";
        public static string FileUploaded = "File is uploaded";
        public static string ThisCarHasAlreadyFiveImages = "This car has already five cars,so you cannot add image for this car";
        public static string ThereisNoImage = "There is no image buddy,Sorry.";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is wrong";
        public static string LoginSuccessfully = "Login successfully";
        public static string UserAlreadyExist = "User already exist";
        public static string RegisteredSuccesfully = "Registered successfully";
        public static string AccessTokenCreated = "Access Token Created";
        public static string AuthorizationDenied = "Authorization Denied! You cannot proceed this process";
    }
}
