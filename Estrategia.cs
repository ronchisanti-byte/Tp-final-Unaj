
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using tp1;

namespace tpfinal
{

	public class Estrategia
	{
        public String Consulta1(List<string> datos)
        {
            string result = "Implementar";
            return result;
        }

        public List<Dato> BuscarConOrden(List<string> datos, int cantidad,List<Dato>collected)
        {
			

			for (int i = 0; i < datos.Count; i++)
			{
				string palActual = datos[i];
				bool existePal = false;


				for (int j = 0; j < collected.Count; j++)
				{
					if (collected[j].texto == palActual)
					{
						existePal = true;
						break;
					}
				}

				if (existePal == false)
				{
					int cuantasHay = Repetidas(datos, palActual);
					Dato nuevaTarjeta = new Dato(cuantasHay,palActual);
		
				collected.Add(nuevaTarjeta);

				}
			}
			BuscarXseleccion(collected);
       
            return collected;

        }
		private int Repetidas(List<string> datos, string pal)
		{
			int repet = 0;
			int n = datos.Count;
			for (int i = 0; i < n; i++)
			{


				if (datos[i] == pal)
				{
					repet++;
				}
			}
			return repet;

		}
		public String Consulta2(List<string> datos)
		{
			string result = "Implementar";

			return result;
		}



		public String Consulta3(List<string> datos)
		{
			string result = "Implementar";

			return result;
		}


		private void BuscarXseleccion(List<Dato> listacontada)

		{ 
			int totalTarjetas=listacontada.Count;

			for (int i = 0; i < totalTarjetas-1; i++)
			{
				int targeMayor = i;

				for (int j = i + 1; j < totalTarjetas; j++)

				{
					if (listacontada[j].ocurrencia > listacontada[targeMayor].ocurrencia)
					{
						targeMayor=j; 



						
					}
				}
                Dato aux = listacontada[targeMayor];
                listacontada[targeMayor] = listacontada[i];
                listacontada[i] = aux;


            }
		
		}

        public List<Dato> BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
        {
            for (int i = 0; i < datos.Count; i++)
            {
                string palActual = datos[i];
                bool existePal = false;

                for (int j = 0; j < collected.Count; j++)
                {
                    if (collected[j].texto == palActual)
                    {
                        existePal = true;
                        break;
                    }
                }

                if (existePal == false)
                {
                    int cuantasHay = Repetidas(datos, palActual);
                    Dato nuevaTarjeta = new Dato(cuantasHay, palActual);
                    collected.Add(nuevaTarjeta);
                }
            }

            int n = collected.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (collected[j].ocurrencia < collected[j + 1].ocurrencia)
                    {
                        Dato aux = collected[j];
                        collected[j] = collected[j + 1];
                        collected[j + 1] = aux;
                    }
                }
            }

            return collected;
        }



        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
			for (int i = 0; i < datos.Count; i++)
			{
				string palActual = datos[i];
				bool existePal = false;

				for (int j = 0; j < collected.Count; j++)
				{
					if (collected[j].texto==palActual)
					{
						existePal = true;
						break;
					}
					if(existePal==false)
					{
						int cuantasHay=Repetidas(datos,palActual);
						Dato nuevaTarjeta=new Dato(cuantasHay, palActual);
						collected.Add(nuevaTarjeta);
					}
				}
			}
			int n=collected.Count;
			for(int i=n/2-1;i>=0;i--)
			{
				HacerHeap(collected,n,i);
			}
			//Sacar y ordenar
			for(int i=n-1;i>0;i--)
			{
				Dato aux = collected[0];
				collected[0] = collected[i];
				collected[i]=aux;

				HacerHeap(collected,n,i);
			}
			
            
        }
		//mi herramienta para despues hacerheap
		private void HacerHeap(List<Dato>lista,int n,int i)
		{
			int menor = i;
			int hijoIzq = 2 * i + 1;
			int hijoDer=2 * i + 2;

			if(hijoIzq>n && lista[hijoIzq].ocurrencia < lista[menor].ocurrencia)
			{
				menor = hijoIzq;
			}
			if(hijoDer>n && lista[hijoDer].ocurrencia < lista[menor].ocurrencia)
			{
				menor=hijoDer;
			}
			if(menor!=i)
			{
				Dato aux = lista[i];
				lista[i] = lista[menor];
				lista[menor] = aux;
				HacerHeap(lista,n,i);
			}
		}




    }
}