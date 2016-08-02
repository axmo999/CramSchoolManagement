using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CramSchoolManagement.Areas.Students.Models
{
    public class chartConfig
    {
        public chartConfig()
        {
            this.type = "radar";

            this.data = new Data();
            this.options = new Options();
            this.data.labels = new List<string>();
            this.data.datasets = new List<Dataset>();

            this.options.legend = new Legend();
            this.options.scale = new Scale();
            this.options.title = new Title();

            this.options.scale.gridLines = new GridLines();
            this.options.scale.ticks = new Ticks();

            this.options.legend.position = "top";
            this.options.title.display = false;
            this.options.scale.reverse = false;
            this.options.scale.ticks.beginAtZero = true;
            this.options.scale.ticks.max = 100;
            this.options.scale.ticks.min = 0;
        }

        public string type { get; set; }
        public Data data { get; set; }
        public Options options { get; set; }

        public class Dataset
        {
            public string label { get; set; }
            public string backgroundColor { get; set; }
            public string pointBackgroundColor { get; set; }
            public List<string> data { get; set; }
        }

        public class Data
        {
            public List<string> labels { get; set; }
            public List<Dataset> datasets { get; set; }
        }

        public class Legend
        {
            public string position { get; set; }
        }

        public class Title
        {
            public bool display { get; set; }
            public string text { get; set; }
        }

        public class GridLines
        {
            public List<string> color { get; set; }
        }

        public class Ticks
        {
            public bool beginAtZero { get; set; }
            public int min { get; set; }
            public int max { get; set; }
        }

        public class Scale
        {
            public bool reverse { get; set; }
            public GridLines gridLines { get; set; }
            public Ticks ticks { get; set; }
        }

        public class Options
        {
            public Legend legend { get; set; }
            public Title title { get; set; }
            public Scale scale { get; set; }
        }
    }
}