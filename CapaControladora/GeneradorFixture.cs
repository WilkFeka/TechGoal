using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class GeneradorFixture
    {
        public interface IGeneradorDeFixture
        {
            List<Llave> GenerarFixture(List<int> equipos, int cantEquipos, int idTorneo);
        }

        public class GeneradorLlaves : IGeneradorDeFixture
        {
            public List<Llave> GenerarFixture(List<int> equipos, int cantEquipos, int idTorneo)
            {
                var random = new Random();
                var equiposAleatorios = equipos.OrderBy(x => random.Next()).ToList(); // Mezcla aleatoria de equipos

                string instancia;
                if (cantEquipos == 2)
                {
                    instancia = "Final";
                } else if ( cantEquipos == 4)
                {
                    instancia = "Semifinal";
                } else if (cantEquipos == 8)
                {
                    instancia = "4tos";
                } else
                {
                    instancia = (cantEquipos / 2) + "vos";
                }

                var llaves = new List<Llave>();
                for (int i = 0; i < equiposAleatorios.Count; i += 2)
                {
                    var llave = new Llave
                    {
                        id_local = equiposAleatorios[i],
                        id_visitante = equiposAleatorios[i + 1],
                        instancia = instancia, 
                        id_torneo = idTorneo, 
                        golesL = null,
                        golesV = null,
                        ganador = null
                    };

                    llaves.Add(llave);
                }

                return llaves;
            }
        }

        // Implementación para Liga (Round-robin)
        //public class GeneradorLiga : IGeneradorDeFixture
        //{
        //    public List<string> GenerarFixture(List<string> equipos)
        //    {
        //        var fixture = new List<string>();
        //        for (int i = 0; i < equipos.Count; i++)
        //        {
        //            for (int j = i + 1; j < equipos.Count; j++)
        //            {
        //                fixture.Add($"{equipos[i]} vs {equipos[j]}");
        //            }
        //        }

        //        return fixture;
        //    }
        //}

        public class GeneradorDeTorneo
        {
            private IGeneradorDeFixture _generadorDeFixture;

            public GeneradorDeTorneo(IGeneradorDeFixture generadorDeFixture)
            {
                _generadorDeFixture = generadorDeFixture;
            }

            public void SetGeneradorDeFixture(IGeneradorDeFixture generadorDeFixture)
            {
                _generadorDeFixture = generadorDeFixture;
            }

            public List<Llave> CrearFixture(List<int> equipos, int cantEquipos, int idTorneo)
            {
                var fixture = _generadorDeFixture.GenerarFixture(equipos, cantEquipos, idTorneo);
                return fixture;
            }
        }
    }
}
