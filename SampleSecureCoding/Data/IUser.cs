using System;
using SampleSecureCoding.Models;

namespace SampleSecureCoding.Data;

public interface IUser
{
    User Registration(User user);
    User Login(User user);
}
