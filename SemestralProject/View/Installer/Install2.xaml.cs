using SemestralProject.View.Enums;
using SemestralProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemestralProject.View.Installer
{
    /// <summary>
    /// Interaction logic for Install2.xaml
    /// </summary>
    public partial class Install2 : UserControl
    {
        /// <summary>
        /// Handler of the whole instalation process.
        /// </summary>
        private readonly InstallViewModel install;

        /// <summary>
        /// Actual step of second stage of installation.
        /// </summary>
        private Install2Step step;

        /// <summary>
        /// Creates second stage of the installation.
        /// </summary>
        /// <param name="install">Handler of the whole installation process.</param>
        /// <param name="delete">Number of deleted tables.</param>
        /// <param name="sequences">Number of created sequences.</param>
        /// <param name="tables">Number of created tables.</param>
        /// <param name="relations">Number of created relations.</param>
        /// <param name="data">Number of created data.</param>
        /// <param name="triggers">Number of created triggers.</param>
        /// <param name="packages">Number of created packages.</param>
        public Install2(InstallViewModel install, int delete, int sequences, int tables, int relations, int data, int triggers, int packages)
        {
            this.install = install;
            InitializeComponent();
            this.LabelDeleteTotal.Content = delete;
            this.LabelSequencesTotal.Content = sequences;
            this.LabelTablesTotal.Content = tables;
            this.LabelRelationsTotal.Content = relations;
            this.LabelDataTotal.Content = data;
            this.LabelTriggersTotal.Content = triggers;
            this.LabelPackagesTotal.Content = packages;
        }

        /// <summary>
        /// Initializes whole view.
        /// </summary>
        public void Initialize()
        {
            this.ResetCounters();
            this.ResetView();
            this.HideResults();
            this.HideProgressRings();
        }

        /// <summary>
        /// Resets counters of progress.
        /// </summary>
        private void ResetCounters()
        {
            this.LabelSequencesActual.Content = "0";
            this.LabelTablesActual.Content = "0";
            this.LabelRelationsActual.Content = "0";
            this.LabelDataActual.Content = "0";
        }

        /// <summary>
        /// Resets whole view to its default state.
        /// </summary>
        private void ResetView()
        {
            this.LabelConnection.FontWeight = FontWeights.Normal;

            this.LabelDelete1.FontWeight = FontWeights.Normal;
            this.LabelDelete2.FontWeight = FontWeights.Normal;
            this.LabelDelete3.FontWeight = FontWeights.Normal;
            this.LabelDeleteActual.FontWeight = FontWeights.Normal;
            this.LabelDeleteTotal.FontWeight = FontWeights.Normal;

            this.LabelSequences1.FontWeight = FontWeights.Normal;
            this.LabelSequences2.FontWeight = FontWeights.Normal;
            this.LabelSequences3.FontWeight = FontWeights.Normal;
            this.LabelSequencesActual.FontWeight = FontWeights.Normal;
            this.LabelSequencesTotal.FontWeight = FontWeights.Normal;

            this.LabelTables1.FontWeight = FontWeights.Normal;
            this.LabelTables2.FontWeight = FontWeights.Normal;
            this.LabelTables3.FontWeight = FontWeights.Normal;
            this.LabelTablesActual.FontWeight = FontWeights.Normal;
            this.LabelTablesTotal.FontWeight = FontWeights.Normal;

            this.LabelRelations1.FontWeight = FontWeights.Normal;
            this.LabelRelations2.FontWeight = FontWeights.Normal;
            this.LabelRelations3.FontWeight = FontWeights.Normal;
            this.LabelRelationsActual.FontWeight = FontWeights.Normal;
            this.LabelRelationsTotal.FontWeight = FontWeights.Normal;

            this.LabelData1.FontWeight = FontWeights.Normal;
            this.LabelData2.FontWeight = FontWeights.Normal;
            this.LabelData3.FontWeight = FontWeights.Normal;
            this.LabelDataActual.FontWeight = FontWeights.Normal;
            this.LabelDataTotal.FontWeight = FontWeights.Normal;

            this.LabelTriggers1.FontWeight = FontWeights.Normal;
            this.LabelTriggers2.FontWeight = FontWeights.Normal;
            this.LabelTriggers3.FontWeight = FontWeights.Normal;
            this.LabelTriggersActual.FontWeight = FontWeights.Normal;
            this.LabelTriggersTotal.FontWeight = FontWeights.Normal;

            this.LabelPackages1.FontWeight = FontWeights.Normal;
            this.LabelPackages2.FontWeight = FontWeights.Normal;
            this.LabelPackages3.FontWeight = FontWeights.Normal;
            this.LabelPackagesActual.FontWeight = FontWeights.Normal;
            this.LabelPackagesTotal.FontWeight = FontWeights.Normal;
        }

        /// <summary>
        /// Hides all progress rings.
        /// </summary>
        private void HideProgressRings()
        {
            this.ProgressRingConnection.Visibility = Visibility.Hidden;
            this.ProgressRingDelete.Visibility = Visibility.Hidden;
            this.ProgressRingSequences.Visibility = Visibility.Hidden;
            this.ProgressRingTables.Visibility = Visibility.Hidden;
            this.ProgressRingRelations.Visibility = Visibility.Hidden;
            this.ProgressRingData.Visibility = Visibility.Hidden;
            this.ProgressRingTriggers.Visibility = Visibility.Hidden;
            this.ProgressRingPackages.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Hides all elements with results of steps.
        /// </summary>
        private void HideResults()
        {
            this.LabelConnectionFail.Visibility = Visibility.Hidden;
            this.LabelConnectionSuccess.Visibility = Visibility.Hidden;

            this.LabelDeleteFail.Visibility = Visibility.Hidden;
            this.LabelDeleteSuccess.Visibility = Visibility.Hidden;

            this.LabelSequencesFail.Visibility = Visibility.Hidden;
            this.LabelSequencesSuccess.Visibility = Visibility.Hidden;

            
            this.LabelTablesFail.Visibility = Visibility.Hidden;
            this.LabelTablesSuccess.Visibility = Visibility.Hidden;

            this.LabelDataFail.Visibility = Visibility.Hidden;
            this.LabelDataSuccess.Visibility = Visibility.Hidden;

            this.LabelTriggersFail.Visibility = Visibility.Hidden;
            this.LabelTriggersSuccess.Visibility = Visibility.Hidden;

            this.LabelPackagesFail.Visibility = Visibility.Hidden;
            this.LabelPackagesSuccess.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Switches actually displayed step of second stage of installation.
        /// </summary>
        /// <param name="step">New step of second stage of installation.</param>
        public void SwitchStep(Install2Step step)
        {
            this.step = step;
            this.ResetView();
            this.HideProgressRings();
            this.ShowStep();
        }

        /// <summary>
        /// Shows actual step of second stage of installation.
        /// </summary>
        private void ShowStep()
        {
            switch(this.step)
            {
                case Install2Step.Connection:
                    {
                        this.LabelConnection.FontWeight = FontWeights.Bold;
                        this.ProgressRingConnection.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Deletion:
                    {
                        this.LabelDelete1.FontWeight = FontWeights.Bold;
                        this.LabelDelete2.FontWeight = FontWeights.Bold;
                        this.LabelDelete3.FontWeight = FontWeights.Bold;
                        this.LabelDeleteActual.FontWeight = FontWeights.Bold;
                        this.LabelDeleteTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingDelete.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Sequences:
                    {
                        this.LabelSequences1.FontWeight = FontWeights.Bold;
                        this.LabelSequences2.FontWeight = FontWeights.Bold;
                        this.LabelSequences3.FontWeight = FontWeights.Bold;
                        this.LabelSequencesActual.FontWeight = FontWeights.Bold;
                        this.LabelSequencesTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingSequences.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Tables:
                    {
                        this.LabelTables1.FontWeight = FontWeights.Bold;
                        this.LabelTables2.FontWeight = FontWeights.Bold;
                        this.LabelTables3.FontWeight = FontWeights.Bold;
                        this.LabelTablesActual.FontWeight = FontWeights.Bold;
                        this.LabelTablesTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingTables.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Relations:
                    {
                        this.LabelRelations1.FontWeight = FontWeights.Bold;
                        this.LabelRelations2.FontWeight = FontWeights.Bold;
                        this.LabelRelations3.FontWeight = FontWeights.Bold;
                        this.LabelRelationsActual.FontWeight = FontWeights.Bold;
                        this.LabelRelationsTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingRelations.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Data:
                    {
                        this.LabelData1.FontWeight = FontWeights.Bold;
                        this.LabelData2.FontWeight = FontWeights.Bold;
                        this.LabelData3.FontWeight = FontWeights.Bold;
                        this.LabelDataActual.FontWeight = FontWeights.Bold;
                        this.LabelDataTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingData.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Triggers:
                    {
                        this.LabelTriggers1.FontWeight = FontWeights.Bold;
                        this.LabelTriggers2.FontWeight = FontWeights.Bold;
                        this.LabelTriggers3.FontWeight = FontWeights.Bold;
                        this.LabelTriggersActual.FontWeight = FontWeights.Bold;
                        this.LabelTriggersTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingTriggers.Visibility = Visibility.Visible;
                        break;
                    }
                case Install2Step.Packages:
                    {
                        this.LabelPackages1.FontWeight = FontWeights.Bold;
                        this.LabelPackages2.FontWeight = FontWeights.Bold;
                        this.LabelPackages3.FontWeight = FontWeights.Bold;
                        this.LabelPackagesActual.FontWeight = FontWeights.Bold;
                        this.LabelPackagesTotal.FontWeight = FontWeights.Bold;
                        this.ProgressRingPackages.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        /// <summary>
        /// Increments counter of the stage.
        /// </summary>
        public void IncrementCounter()
        {
            Label? label = null;
            switch(this.step)
            {
                case Install2Step.Connection: label = null;                       break;
                case Install2Step.Deletion:   label = this.LabelDeleteActual;     break;
                case Install2Step.Sequences:  label = this.LabelSequencesActual;  break;
                case Install2Step.Tables:     label = this.LabelTablesActual;     break;
                case Install2Step.Relations:  label = this.LabelRelationsActual;  break;
                case Install2Step.Data:       label = this.LabelDataActual;       break;
                case Install2Step.Triggers:   label = this.LabelTriggersActual;   break;
                case Install2Step.Packages:   label = this.LabelPackagesActual;   break;
                default:                      label = null;                       break;
            }
            if (label is not null)
            {
                int actual = int.Parse(label.Content.ToString() ?? "0");
                label.Content = actual + 1;
            }
        }

        /// <summary>
        /// Sets actual step to be failed.
        /// </summary>
        public void Fail()
        {
            Label? label;
            this.HideProgressRings();
            switch(this.step)
            {
                case Install2Step.Connection: label = this.LabelConnectionFail;  break;
                case Install2Step.Deletion:   label = this.LabelDeleteFail;      break;
                case Install2Step.Sequences:  label = this.LabelSequencesFail;   break;
                case Install2Step.Tables:     label = this.LabelTablesFail;      break;
                case Install2Step.Relations:  label = this.LabelRelationsFail;   break;
                case Install2Step.Data:       label = this.LabelDataFail;        break;
                case Install2Step.Triggers:   label = this.LabelTriggersFail;    break;
                case Install2Step.Packages:   label = this.LabelPackagesFail;    break;
                default:                      label = null;                      break;
            }
            if (label is not null)
            {
                label.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Sets actual step to be successfull.
        /// </summary>
        public void Success()
        {
            Label? label;
            this.HideProgressRings();
            switch (this.step)
            {
                case Install2Step.Connection: label = this.LabelConnectionSuccess; break;
                case Install2Step.Deletion:   label = this.LabelDeleteSuccess;     break;
                case Install2Step.Sequences:  label = this.LabelSequencesSuccess;  break;
                case Install2Step.Tables:     label = this.LabelTablesSuccess;     break;
                case Install2Step.Relations:  label = this.LabelRelationsSuccess;  break;
                case Install2Step.Data:       label = this.LabelDataSuccess;       break;
                case Install2Step.Triggers:   label = this.LabelTriggersSuccess;   break;
                case Install2Step.Packages:   label = this.LabelPackagesSuccess;   break;
                default:                      label = null;                        break;
            }
            if (label is not null)
            {
                label.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Unselects actual step.
        /// </summary>
        public void UnselectStep()
        {
            this.HideProgressRings();
            this.ResetView();
        }
    }
}
