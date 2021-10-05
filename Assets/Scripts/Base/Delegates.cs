namespace VEngine
{
	public delegate void Delegate0();
	public delegate void Delegate1<T>(T value);
	public delegate void Delegate2<T1, T2>(T1 value1, T2 value2);
	public delegate void Delegate3<T1, T2, T3>(T1 value1, T2 value2, T3 value3);
	public delegate void Delegate4<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4);

	public delegate R Delegate0<R>();
	public delegate R Delegate1<R, T>(T value);
	public delegate R Delegate2<R, T1, T2>(T1 value1, T2 value2);
	public delegate R Delegate3<R, T1, T2, T3>(T1 value1, T2 value2, T3 value3);
	public delegate R Delegate4<R, T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4);
}
