namespace Model.VO
{
    public class PlayerVO : SpaceShipVO
    {
        private string nameData = "Enemy";
        public PlayerVO()
        {
            LoadData(nameData);
        }
    }
}
