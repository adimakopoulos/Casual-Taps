using System;

[AttributeUsage(AttributeTargets.Field)]
public  class SetMeInInspector : Attribute
{
   
    public  SetMeInInspector(Object any)
    {
        
        if (any is null)
        {
            throw new ArgumentNullException(nameof(any));
        }
    }

    

}




