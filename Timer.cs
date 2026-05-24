using System;

public class TimeKeepingS
{
    /// <summary>
    /// 起始时间
    /// </summary>
    protected long StartTime = 0;

    private bool StartState = false;

    /// <summary>
    /// 开始计时
    /// </summary>
    public void Start()
    {
        this.StartTime = DateTime.Now.Ticks / 10000;
        this.StartState = true;
    }

    /// <summary>
    /// 获取计时时长:ms
    /// </summary>
    public int GetEndTime()
    {
        return this.StartState ? (int)(DateTime.Now.Ticks / 10000 - this.StartTime) : 0;
    }

    /// <summary>
    /// 停止计时
    /// </summary>
    public void Stop()
    {
        this.StartState = false;
    }
}