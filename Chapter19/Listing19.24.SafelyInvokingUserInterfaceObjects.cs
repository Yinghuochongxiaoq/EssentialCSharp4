﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_24
{
    using System;
    using System.Windows.Threading;
    using System.Windows;
    
    public static class UIAction
    {
        public static void Invoke<T>(
            Action<T> action, T parameter)
        {
            Invoke(() => action(parameter));
        }
        public static void Invoke(Action action)
        {
            DispatcherObject dispatcher =
                Application.Current;
            if (dispatcher == null
                || dispatcher.CheckAccess()
                || dispatcher.Dispatcher == null
                )
            {
                action();
            }
            else
            {
                SafeInvoke(action);
            }
        }

        // We want to catch all exceptions here 
        // so we can rethrow
        private static void SafeInvoke(Action action)
        {
            Exception exceptionThrown = null;
            Action target = () =>
            {
                try
                {
                    action();
                }
                catch (Exception exception)
                {
                    exceptionThrown = exception;
                }
            };
            Application.Current.Dispatcher.Invoke(target);
            if (exceptionThrown != null)
            {
                throw exceptionThrown;
            }
        }
    }
}