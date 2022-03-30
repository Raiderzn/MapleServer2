﻿using NLog;

namespace MapleServer2.Tools;

public static class TaskUtils
{
    public static void WaitForTask(Task task)
    {
        try
        {
            task.Wait();
        }
        catch (AggregateException) { } // CancellationToken.Cancel(), then task.Wait() always throws AggregateException
        catch (Exception e)
        {
            LogManager.GetCurrentClassLogger().Error(e);
        }
    }
}