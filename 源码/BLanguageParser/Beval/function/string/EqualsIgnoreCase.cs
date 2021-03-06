﻿using System;
using System.Collections;

public class EqualsIgnoreCase : Function
{
    public virtual string Name
    {
        get
        {
            return "equalsIgnoreCase";
        }
    }

    public virtual FunctionResult execute(Evaluator evaluator, string arguments)
    {
        string result = null;
        string exceptionMessage = "Two string arguments are required.";
        ArrayList strings = FunctionHelper.getStrings(arguments, EvaluationConstants.FUNCTION_ARGUMENT_SEPARATOR);
        if (strings.Count != 2)
        {
            throw new FunctionException(exceptionMessage);
        }
        try
        {
            string argumentOne = FunctionHelper.trimAndRemoveQuoteChars((string)strings[0], evaluator.QuoteCharacter);
            string argumentTwo = FunctionHelper.trimAndRemoveQuoteChars((string)strings[1], evaluator.QuoteCharacter);
            if (argumentOne.Equals(argumentTwo, StringComparison.CurrentCultureIgnoreCase))
            {
                result = EvaluationConstants.BOOLEAN_STRING_TRUE;
            }
            else
            {
                result = EvaluationConstants.BOOLEAN_STRING_FALSE;
            }
        }
        catch (FunctionException fe)
        {
            throw new FunctionException(fe.Message, fe);
        }
        catch (Exception e)
        {
            throw new FunctionException(exceptionMessage, e);
        }
        return new FunctionResult(result, FunctionConstants.FUNCTION_RESULT_TYPE_NUMERIC);
    }
}
