using System;
using CH.Testing.T1.Interface;

namespace CH.Testing.T1.Component
{
    internal sealed class CurrentDateTimeProvider : IDateTimeProvider
    {
        DateTime IDateTimeProvider.Value
        {
            get { return DateTime.Now; }
        }
    }
}