using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;

namespace Core.Controllers
{
    class DostupOgranichenie
    {
        DBNpgsql db = new DBNpgsql();
        public int id_dostup;
        //получаем список доступов к базе 
        public DataTable GetDostupUser(string user, string password)
        {
            DataTable dt = db.GetByQuery("Select id_доступа FROM public.пользователи WHERE пользователь='" + user + "' AND пароль='" + password + "'");
           if (dt.Rows.Count > 0)
            {
                id_dostup = Convert.ToInt32(dt.Rows[0][0]);
                dt= db.GetByQuery("Select dk.контроль " +
                       "FROM public.доступ_категории dk, public.доступ_пользователей dp, public.доступ_группа dg " +
                       "WHERE dp.id_доступа=dg.id_доступа AND dp.id_категория=dk.id_категория AND dp.id_доступа='" + id_dostup + "'");

            }
            return dt;

        }

        public DataTable GetUser()
        {
            return db.GetByQuery("Select фио, пользователь FROM public.пользователи ORDER BY фио ASC");
        }

        public DataTable GetUserByDostup(int id_dostupa)
        {
            return db.GetByQuery("Select пользователь, фио, id_пользователь, пароль FROM public.пользователи WHERE id_доступа='" + id_dostupa + "' ORDER BY пользователь ASC");
        }

        public DataTable GetUserByFio(int id_dostupa, string fio)
        {
            return db.GetByQuery("Select пользователь, фио, id_пользователь, пароль FROM public.пользователи WHERE id_доступа='" + id_dostupa + "' AND фио='" + fio + "' ORDER BY пользователь ASC");
        }

        public void UpdateUserByDostup(string user, int id_dostupa, string fio, int idUser,string password)
        {
            db.insertUpdateToDB("UPDATE public.пользователи SET id_доступа='" + id_dostupa + "', пользователь='" + user + "', пароль= '" + password + "' " +
                "WHERE фио='" + fio + "' AND id_пользователь='" + idUser + "'");
        }

        public void DeleteUserFromDostup(int idUser)
        {
            db.insertUpdateToDB("UPDATE public.пользователи SET id_доступа=0 " +
                "WHERE id_пользователь='" + idUser + "'");
        }

        public void UpdateUserAddDostup(int id_dostupa, string fio)
        {
            db.insertUpdateToDB("UPDATE public.пользователи SET id_доступа='" + id_dostupa + "'"+
                "WHERE фио='" + fio + "'");
        }

        public void InsertNewUser(int id_dostupa, string fio)
        {
            db.insertUpdateToDB("INSERT INTO public.пользователи (фио, id_доступа) VALUES " +
                "('" + fio + "', '" + id_dostupa + "')");
        }

        public DataTable GetGruppaName()
        {
            return db.GetByQuery("Select DISTINCT название FROM public.доступ_группа ORDER BY название ASC");
        }

        public DataTable GetGruppaDostupa()
        {
            return db.GetByQuery("Select DISTINCT dg.название FROM public.доступ_пользователей dp, public.доступ_группа dg WHERE dp.id_доступа=dg.id_доступа ORDER BY dg.название ASC");
        }



        public DataTable GetGruppaNameIDByName(string name)
        {
            return db.GetByQuery("Select id_доступа FROM public.доступ_группа WHERE название='" + name + "' ");
        }

        public DataTable GetGruppaDostupaByName(string name)
        {
            return db.GetByQuery("Select dg.id_доступа, dg.описание_группы FROM " +
                "public.доступ_пользователей dp, public.доступ_группа dg " +
                "WHERE dp.id_доступа=dg.id_доступа AND dg.название='" + name + "' ORDER BY dg.название ASC");
        }

        public DataTable GetAllKategoriaDostupa()
        {
            return db.GetByQuery("Select DISTINCT название_категории " +
                "FROM public.доступ_категории ORDER BY название_категории ASC");
        }

        public DataTable GetKategoriaDostupa(string name)
        {
            return db.GetByQuery("Select DISTINCT id_категория, название_категории, контроль " +
                "FROM public.доступ_категории WHERE название_категории='" + name + "' ORDER BY название_категории ASC");
        }

        public DataTable GetKategoriaDostupaByNameKategorii(string name, int id)
        {
            return db.GetByQuery("Select dk.id_категория, dk.название_категории, dk.контроль " +
                "FROM public.доступ_категории dk, public.доступ_пользователей dp, public.доступ_группа dg " +
                "WHERE dp.id_доступа=dg.id_доступа AND dp.id_категория=dk.id_категория AND dk.название_категории='" + name + "' AND dp.id_доступа='" + id + "' ORDER BY dk.название_категории ASC");
        }

        public void UpdateGruppaDostupa(string name, string opisanie, int id)
        {
            db.insertUpdateToDB("UPDATE public.доступ_группа SET название='" + name + "', описание_группы='" + opisanie + "' WHERE id_доступа='" + id + "'");
        }

        public void InsertGruppaPolzovateley(int id_dostupa)
        {
            db.insertUpdateToDB("INSERT INTO public.доступ_пользователей (id_доступа) VALUES ('" + id_dostupa + "')");
        }

        public void DeleteGruppaDostupa(int id)
        {
            db.insertUpdateToDB("DELETE public.доступ_группа WHERE id_доступа='" + id + "'");
        }
        
        public void InsertGruppaDostupa(string name)
        {
            db.insertUpdateToDB("INSERT INTO public.доступ_группа(название) VALUES('" + name + "')");
            
        }

        public DataTable GetKategoriaDostupa(int id)  /*id это группа*/
        {
                return db.GetByQuery("Select dk.id_категория, dk.название_категории, dk.контроль " +
                "FROM public.доступ_категории dk, public.доступ_пользователей dp, public.доступ_группа dg " +
                "WHERE dp.id_доступа=dg.id_доступа AND dp.id_категория=dk.id_категория AND dp.id_доступа='" + id + "' ORDER BY dk.название_категории ASC");

        }

        public void UpdateKategoriaDostupa(string name, string kontrol, int id_kategoria, int id_dostupa, bool trueFalse)
        {

            db.insertUpdateToDB("UPDATE public.доступ_категории SET название_категории='" + name + "', контроль='" + kontrol + "' " +
                "WHERE id_категория='" + id_kategoria + "'");

            if (trueFalse==false)
               db.insertUpdateToDB("DELETE FROM public.доступ_пользователей " +
                   "WHERE id_категория='" + id_kategoria + "' AND id_доступа='" + id_dostupa + "'");
        }

        public void InsertKategoriaToDostupPolzovatey(string name, int id_dostupa)
        {
            int id_kategoria=Convert.ToInt32(GetKategoriaDostupa(name).Rows[0][0]);
            db.insertUpdateToDB("INSERT INTO public.доступ_пользователей (id_категория, id_доступа) VALUES ('" + id_kategoria + "', '" + id_dostupa + "')");
        }

        public bool IsKategoriExist(string name, int id_dostupa)
        {
            DataTable dt = db.GetByQuery("SELECT exists (SELECT 1 FROM public.доступ_пользователей dp, public.доступ_категории dk WHERE dp.id_категория=dk.id_категория AND dk.название_категории = '" + name + "' " +
                "AND dp.id_доступа='" + id_dostupa + "' LIMIT 1)");
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }
        


    }
}
