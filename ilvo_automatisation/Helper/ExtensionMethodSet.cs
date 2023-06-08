﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation.Helper;

public static class ExtensionMethodSet
{
    // public static IQueryable Set(this DbContext context, Type T)
    // {
    //     // Get the generic type definition
    //     MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);
    //
    //     // Build a method with the specific type argument you're interested in
    //     method = method.MakeGenericMethod(T);
    //
    //     return method.Invoke(context, null) as IQueryable;
    // }
    
    public static IQueryable<T> Set<T>(this DbContext context) where T : class 
    {
        // Get the generic type definition 
        MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);
    
        // Build a method with the specific type argument you're interested in 
        method = method.MakeGenericMethod(typeof(T)); 
    
        return method.Invoke(context, null) as IQueryable<T>;
    } 
    public static IQueryable Set(this DbContext context, Type T) 
    {
        var method = typeof(DbContext).GetMethods().Single(p =>
            p.Name == nameof(DbContext.Set) && p.ContainsGenericParameters && !p.GetParameters().Any());
                               
        // Build a method with the specific type argument you're interested in
        method = method.MakeGenericMethod(T);
    
        return method.Invoke(context, null) as IQueryable;
    }
    
}