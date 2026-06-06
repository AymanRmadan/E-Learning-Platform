namespace E_Learning.BLL
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //if there is prop in response is not the same name in model use this way
            // var config = new TypeAdapterConfig();



            // config.NewConfig<Learner, GetAllLearnersResponse>()
            //.Map(dest => dest.Id, src => src.Id)
            //.Map(dest => dest.FullName, src => src.FullName)
            //.Map(dest => dest.Email, src => src.Email)
            //.Map(dest => dest.NationalId, src => src.NationalId)
            //.Map(dest => dest.Department, src => src.Department);

        }
    }
}
