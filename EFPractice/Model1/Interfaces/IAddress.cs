namespace EFPractice.Model1.Interfaces
{
    public interface IAddress
    {
        public IEnumerable<Address> GetAllAddresses();
        public Address GetAddressById(int index);
    }
}
