namespace Model.VO
{
    public class EnemyVO : SpaceShipVO
    {
        private string nameData = "Player";
        public EnemyVO()
        {
            LoadData(nameData);
        }
    }
}
