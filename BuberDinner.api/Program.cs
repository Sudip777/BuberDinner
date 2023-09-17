using BuberDinner.Api.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();


var app = builder.Build();


app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.Run(); import React, { useState } from 'react';

function FormValidationExample()
{
    const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: '',
  });

const [errors, setErrors] = useState({
    username: '',
  email: '',
  password: '',
  });

const validateForm = () => {
    let isValid = true;
    const newErrors = { ...errors };

    // Validate username
    if (formData.username.trim() === '')
    {
        newErrors.username = 'Username is required';
        isValid = false;
    }
    else
    {
        newErrors.username = '';
    }

    // Validate email
    const emailPattern = / ^[^\s@] +@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(formData.email))
    {
        newErrors.email = 'Invalid email address';
        isValid = false;
    }
    else
    {
        newErrors.email = '';
    }

    // Validate password
    if (formData.password.length < 6)
    {
        newErrors.password = 'Password must be at least 6 characters';
        isValid = false;
    }
    else
    {
        newErrors.password = '';
    }

    setErrors(newErrors);
    return isValid;
};

const handleSubmit = (event) => {
    event.preventDefault();
    if (validateForm())
    {
        // Proceed with form submission
        console.log('Form submitted:', formData);
    }
};

const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData({
        ...formData,
      [name]: value,
    });
};

return (

  < form onSubmit ={ handleSubmit}>

    < div >

      < label > Username </ label >

      < input
          type = "text"
          name = "username"
          value ={ formData.username}
onChange ={ handleInputChange}
        />
        { errors.username && < span className = "error" >{ errors.username}</ span >}
      </ div >
      < div >
        < label > Email </ label >
        < input
          type = "email"
          name = "email"
          value ={ formData.email}
onChange ={ handleInputChange}
        />
        { errors.email && < span className = "error" >{ errors.email}</ span >}
      </ div >
      < div >
        < label > Password </ label >
        < input
          type = "password"
          name = "password"
          value ={ formData.password}
onChange ={ handleInputChange}
        />
        { errors.password && < span className = "error" >{ errors.password}</ span >}
      </ div >
      < button type = "submit" > Submit </ button >
    </ form >
  );
}

export default FormValidationExample;
