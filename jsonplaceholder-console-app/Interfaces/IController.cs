interface IController
{
    public Task<string> GetAll();
    public Task ShowAll( bool download = false );
    public Task<string> Find(int id);
     public Task Show(int id);
}