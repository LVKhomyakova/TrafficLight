using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace TrafficLightLib
{
    public class TrafficLight
    {
        bool _statusOn;
        public TrafficLight(IBattery battery, IController controller)
        {
            Battery = battery;
            Controller = controller;
            _statusOn = Battery.GetPower()==0? false : true;
            Lights = new List<Light>()
            {
                new Light(Color.Red),
                new Light(Color.Yellow),
                new Light(Color.Green)
            };
        }
        /// <summary>
        /// Источник питания (постоянный по умолчанию)
        /// </summary>
        public IBattery Battery { get; }
        /// <summary>
        /// Контроллер для установки режимов работы светофора
        /// </summary>
        public IController Controller { get; }
        /// <summary>
        /// Список доступных ламп светофора
        /// </summary>
        public List<Light> Lights { get; }

        /// <summary>
        /// Запустить режим работы светофора
        /// </summary>
        /// <param name="nameMode">Наименование выбранного режима</param>
        public void RunTrafficLight(string nameMode)
        {
            if (_statusOn)
            {
                foreach (var command in Controller.Modes[nameMode])
                {
                    var currentLight = Lights
                        .First(l => l.Color == command.GetColor());
                    if (command.GetAction() == LightAction.On)
                        currentLight.On();
                    else
                        currentLight.Off();
                    int actionTime = command.GetActionTime();
                    Thread.Sleep(actionTime);
                }
            }
            else
                ResetLights();
        }
        /// <summary>
        /// Выключить работу светофора
        /// </summary>
        public void StopTrafficLight()
        {
            _statusOn = false;
        }
        /// <summary>
        /// Проверить вкл/выкл ли светофор
        /// </summary>
        /// <returns></returns>
        public bool GetStatusOn() => _statusOn;
        /// <summary>
        /// Включить лампу (зажечь свет)
        /// </summary>
        /// <param name="color">Цвет лампы</param>
        public void LightOn(Color color)
        {
            if (_statusOn)
            {
                Lights.Where(l => l.Color == color).First().On();
            }
            else
                ResetLights();
        }
        /// <summary>
        /// Выключить лампу (погасить свечение)
        /// </summary>
        /// <param name="color">Цвет лампы</param>
        public void LightOff(Color color)
        {
            if (_statusOn)
            {
                Lights.Where(l => l.Color == color).First().Off();
            }
            else
                ResetLights();
        }
        /// <summary>
        /// Проверить источник питания
        /// </summary>
        /// <returns></returns>
        double CheckPower() => Battery.GetPower();
        /// <summary>
        /// Погасить все лампы
        /// </summary>
        void ResetLights()
        {
            foreach (var item in Lights)
            {
                item.Off();
            }
        }
    }
}
