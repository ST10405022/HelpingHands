using HelpingHands.Models;

namespace HelpingHands.Services
{
    public class ResourceService
    {
        private List<Resource> _resources;

        public ResourceService(List<Resource> resources)
        {
            _resources = resources;
        }

        public List<Resource> GetAvailableResources()
        {
            return _resources.Where(r => r.Quantity > 0).ToList();
        }

        public void AllocateResource(int resourceId, int quantity)
        {
            var resource = _resources.FirstOrDefault(r => r.ResourceID == resourceId);
            if (resource != null && resource.Quantity >= quantity)
            {
                resource.Quantity -= quantity;
            }
        }

        public int GetResourceCount()
        {
            return _resources.Count;
        }

        public void AddSampleData()
        {
            if (!_resources.Any())
            {
                _resources.Add(new Resource { ResourceID = 1, ResourceName = "Clothing", Quantity = 100 });
                _resources.Add(new Resource { ResourceID = 2, ResourceName = "Canned Goods", Quantity = 500 });
            }
        }
    }

}
