using AutoMapper;

namespace Ledd.Dms.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        /// <summary>
        /// In c#, we can provide default implementation inside the interface itself.
        /// Hence classes which dont provide implementation method for Mapping method,
        /// use this default implementation for classes that implement this interface.
        /// It creates a mapping from entity T to the derived type i.e classes that implements 
        /// this interface.
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
