using UnityEngine;

namespace Client.Runtime.Framework.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<out TOutput>
    {
        TOutput Execute();
    }

    public interface ICommand<in TInput, out TOutput>
    {
        TOutput Execute(TInput data);
    }
}