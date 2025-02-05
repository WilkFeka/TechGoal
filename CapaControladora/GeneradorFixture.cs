using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaControladora.GeneradorFixture;

namespace CapaControladora
{
    public class GeneradorFixture
    {
        public interface IGeneradorDeFixture
        {
            List<Partido> GenerarFixture(List<int> equipos, int cantEquipos, int idTorneo);
        }

        public class GeneradorLlaves : IGeneradorDeFixture
        {
            public List<Partido> GenerarFixture(List<int> equipos, int cantEquipos, int idTorneo)
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

                var llaves = new List<Partido>();
                for (int i = 0; i < equiposAleatorios.Count; i += 2)
                {
                    var llave = new Partido
                    {
                        id_local = equiposAleatorios[i],
                        id_visitante = equiposAleatorios[i + 1],
                        instancia = instancia, 
                        id_torneo = idTorneo, 
                        golesL = null,
                        golesV = null,
                        ganador = null,
                        finalizado = false
                    };

                    llaves.Add(llave);
                }

                return llaves;
            }
        }



        public class GeneradorLiga : IGeneradorDeFixture
        {
            public List<Partido> GenerarFixture(List<int> equipos, int cantEquipos, int idTorneo)
            {
                if (equipos == null || equipos.Count == 0)
                    throw new ArgumentException("La lista de equipos no puede estar vacía.");

                // Asegurar que el número de equipos sea impar agregando un "descanso" si es necesario
                if (cantEquipos % 2 != 0)
                {
                    equipos.Add(-1); // Usamos -1 como el ID para representar el descanso
                    cantEquipos++;
                }

                var partidos = new List<Partido>();
                int totalFechas = cantEquipos - 1;
                int mitad = cantEquipos / 2;

                // Generar el fixture usando el algoritmo Round-Robin
                for (int fecha = 0; fecha < totalFechas; fecha++)
                {
                    for (int i = 0; i < mitad; i++)
                    {
                        int local = equipos[i];
                        int visitante = equipos[cantEquipos - 1 - i];

                        // Si el visitante es "descanso", agregar el partido correspondiente
                        if (visitante == -1)
                        {
                            partidos.Add(new Partido
                            {
                                id_partido = partidos.Count + 1,
                                instancia = $"Fecha {fecha + 1}",
                                id_torneo = idTorneo,
                                id_local = local,
                                id_visitante = null
                            });
                        }
                        else if (local == -1)
                        {
                            partidos.Add(new Partido
                            {
                                id_partido = partidos.Count + 1,
                                instancia = $"Fecha {fecha + 1}",
                                id_torneo = idTorneo,
                                id_local = visitante,
                                id_visitante = null
                            });
                        }
                        else
                        {
                            // Alternar local y visitante en cada fecha (sin restricciones de 2 consecutivos)
                            if (fecha % 2 == 0)
                            {
                                partidos.Add(new Partido
                                {
                                    id_partido = partidos.Count + 1,
                                    instancia = $"Fecha {fecha + 1}",
                                    id_torneo = idTorneo,
                                    id_local = local,
                                    id_visitante = visitante
                                });
                            }
                            else
                            {
                                partidos.Add(new Partido
                                {
                                    id_partido = partidos.Count + 1,
                                    instancia = $"Fecha {fecha + 1}",
                                    id_torneo = idTorneo,
                                    id_local = visitante,
                                    id_visitante = local
                                });
                            }
                        }
                    }

                    // Rotación de los equipos (manteniendo el primer equipo fijo)
                    int ultimo = equipos[cantEquipos - 1];
                    for (int j = cantEquipos - 1; j > 1; j--)
                    {
                        equipos[j] = equipos[j - 1];
                    }
                    equipos[1] = ultimo;
                }

                return partidos;
            }
        }



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

            public List<Partido> CrearFixture(List<int> equipos, int cantEquipos, int idTorneo)
            {
                var fixture = _generadorDeFixture.GenerarFixture(equipos, cantEquipos, idTorneo);
                return fixture;
            }
        }
    }
}
