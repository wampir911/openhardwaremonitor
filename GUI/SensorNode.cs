/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2016 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;
using System.Drawing;
using System.Collections.Generic;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;

namespace OpenHardwareMonitor.GUI {
  public class SensorNode : Node {
    
    private ISensor sensor;
    private PersistentSettings settings;
    private UnitManager unitManager;
    private ISensorTextManager sensorTextManager;
    private bool plot = false;
    private Color? penColor = null;

    

    public SensorNode(ISensor sensor, PersistentSettings settings, 
      UnitManager unitManager, ISensorTextManager sensorTextManager) : base() {      
      this.sensor = sensor;
      this.settings = settings;
      this.unitManager = unitManager;
      this.sensorTextManager = sensorTextManager;
      

      bool hidden = settings.GetValue(new Identifier(sensor.Identifier, 
        "hidden").ToString(), sensor.IsDefaultHidden);
      base.IsVisible = !hidden;

      this.Plot = settings.GetValue(new Identifier(sensor.Identifier, 
        "plot").ToString(), false);

      string id = new Identifier(sensor.Identifier, "penColor").ToString();
      if (settings.Contains(id))
        this.PenColor = settings.GetValue(id, Color.Black);
    }

    public override string Text {
      get { return sensor.Name; }
      set { sensor.Name = value; }
    }

    public override bool IsVisible {
      get { return base.IsVisible; }
      set { 
        base.IsVisible = value;
        settings.SetValue(new Identifier(sensor.Identifier,
          "hidden").ToString(), !value);
      }
    }

    public Color? PenColor {
      get { return penColor; }
      set {
        penColor = value;

        string id = new Identifier(sensor.Identifier, "penColor").ToString();
        if (value.HasValue)
          settings.SetValue(id, value.Value);
        else
          settings.Remove(id);

        if (PlotSelectionChanged != null)
          PlotSelectionChanged(this, null);
      }
    }

    public bool Plot {
      get { return plot; }
      set { 
        plot = value;
        settings.SetValue(new Identifier(sensor.Identifier, "plot").ToString(), 
          value);
        if (PlotSelectionChanged != null)
          PlotSelectionChanged(this, null);
      }
    }

    public event EventHandler PlotSelectionChanged;

    public ISensor Sensor {
      get { return sensor; }
    }

    public string Value {
      get { return sensorTextManager.ValueToString(sensor, sensor.Value); }
    }

    public string Min {
      get { return sensorTextManager.ValueToString(sensor, sensor.Min); }
    }

    public string Max {
      get { return sensorTextManager.ValueToString(sensor, sensor.Max); }
    }

    public override bool Equals(System.Object obj) {
      if (obj == null) 
        return false;

      SensorNode s = obj as SensorNode;
      if (s == null) 
        return false;

      return (sensor == s.sensor);
    }

    public override int GetHashCode() {
      return sensor.GetHashCode();
    }

  }
}
