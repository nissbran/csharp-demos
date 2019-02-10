using System;

namespace Demo4_DefaultInterface.Model
{
    public interface IStructuredLogger
    {
        void Information(string message);
        void Information(Exception ex) => Information(ex.Message);
    }
}
