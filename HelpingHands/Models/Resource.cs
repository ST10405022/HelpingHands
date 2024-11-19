namespace HelpingHands.Models
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public int Quantity { get; set; }
        public void AllocateResource() { }
        public void UpdateInventory() { }
    }
}
