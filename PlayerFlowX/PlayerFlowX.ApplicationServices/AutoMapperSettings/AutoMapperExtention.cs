namespace PlayerFlowX.ApplicationServices.AutoMapperSettings
{
    public static class AutoMapperExtention
    {
        public static TDestination MapTo<Tsource, TDestination>(this Tsource source)
        {
            return AutoMapperConfigurations.Mapper.Map<Tsource, TDestination>(source);
        }

        public static TDestination MapTo<Tsource, TDestination>(this Tsource source, TDestination destination)
        {
            return AutoMapperConfigurations.Mapper.Map(source, destination);
        }
    }
}
