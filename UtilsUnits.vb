Option Strict On

Public Class UtilsUnits

    'Public Sub ChangeUnit(SEDoc As SolidEdgeFramework.SolidEdgeDocument)

    '    Dim UnitsOfMeasure As SolidEdgeFramework.UnitsOfMeasure = SEDoc.UnitsOfMeasure
    '    For Each UnitOfMeasure As SolidEdgeFramework.UnitOfMeasure In UnitsOfMeasure
    '        If UnitOfMeasure.Type = SolidEdgeFramework.UnitTypeConstants.igUnitArea Then
    '            UnitOfMeasure.Units = SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaMeterSquared
    '            UnitOfMeasure.Units = SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaMillimeterSquared
    '        End If
    '    Next
    'End Sub

    'Private Property UnitTypeLUT As Dictionary(Of SolidEdgeFramework.UnitTypeConstants, Type)

    Public Sub New()
        'UnitTypeLUT = New Dictionary(Of SolidEdgeFramework.UnitTypeConstants, Type)
        'PopulateUnitTypeLUT()

    End Sub

    'Private Sub PopulateUnitTypeLUT()
    '    UnitTypeLUT(SolidEdgeFramework.UnitTypeConstants.igUnitDistance) = GetType(SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants)
    '    UnitTypeLUT(SolidEdgeFramework.UnitTypeConstants.igUnitArea) = GetType(SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants)

    'End Sub

    Public Sub ListUOMs()
        ' Stress in SEOptions, not Constants.UnitsOfMeasure or Document.UOM
        Dim OutList As New List(Of String)

        For Each UnitOfMeasure As SolidEdgeFramework.UnitTypeConstants In System.Enum.GetValues(GetType(SolidEdgeFramework.UnitTypeConstants))

            OutList.Add("")
            OutList.Add(UnitOfMeasure.ToString)

            Select Case UnitOfMeasure
                Case SolidEdgeFramework.UnitTypeConstants.igUnitDistance ' 1 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitAngle ' 2 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitMass ' 3 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureMassReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitTime ' 4, in SEOptions

                Case SolidEdgeFramework.UnitTypeConstants.igUnitTemperature ' 5 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricCharge ' 6
                Case SolidEdgeFramework.UnitTypeConstants.igUnitLuminousIntensity ' 7
                Case SolidEdgeFramework.UnitTypeConstants.igUnitAmountOfSubstance ' 8
                Case SolidEdgeFramework.UnitTypeConstants.igUnitSolidAngle ' 9

                Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularAcceleration ' 10 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularMomentum ' 11

                Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularVelocity ' 12 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitArea ' 13 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitBodyForce ' 14

                Case SolidEdgeFramework.UnitTypeConstants.igUnitCoefficientOfThermalExpansion ' 15 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitDensity ' 16 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalCapacitance ' 17
                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalConductance ' 18
                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalFieldStrength ' 19
                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalInductance ' 20
                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalPotential ' 21
                Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalResistance ' 22

                Case SolidEdgeFramework.UnitTypeConstants.igUnitEnergy ' 23 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitEntropy ' 24
                Case SolidEdgeFramework.UnitTypeConstants.igUnitFilmCoefficient ' 25 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitForce ' 26 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureForceReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitForcePerArea ' 27 in UOM
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitForcePerDistance ' 28

                Case SolidEdgeFramework.UnitTypeConstants.igUnitFrequency ' 29 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatCapacity ' 30 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureSpecificHeatReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatFluxPerArea ' 31 in UOM
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatFluxPerDistance ' 32 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatSource ' 33
                Case SolidEdgeFramework.UnitTypeConstants.igUnitIlluminance ' 34

                Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearAcceleration ' 35 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearPerAngular ' 36

                Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearVelocity ' 37 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next
                Case SolidEdgeFramework.UnitTypeConstants.igUnitLuminousFlux ' 38
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFieldStrength ' 39
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFlux ' 40
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFluxDensity ' 41
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMassFlowRate ' 42
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMassMomentOfInertia ' 43
                Case SolidEdgeFramework.UnitTypeConstants.igUnitMassPerArea ' 44

                Case SolidEdgeFramework.UnitTypeConstants.igUnitMassPerLength ' 45 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitMomentum ' 46
                Case SolidEdgeFramework.UnitTypeConstants.igUnitPerDistance ' 47

                Case SolidEdgeFramework.UnitTypeConstants.igUnitPower ' 48 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitQuantityOfElectricity ' 49
                Case SolidEdgeFramework.UnitTypeConstants.igUnitRadiantIntensity ' 50
                Case SolidEdgeFramework.UnitTypeConstants.igUnitRotationalStiffness ' 51
                Case SolidEdgeFramework.UnitTypeConstants.igUnitSecondMomentOfArea ' 52

                Case SolidEdgeFramework.UnitTypeConstants.igUnitThermalConductivity ' 53 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitDynamicViscosity ' 54
                Case SolidEdgeFramework.UnitTypeConstants.igUnitKinematicViscosity ' 55

                Case SolidEdgeFramework.UnitTypeConstants.igUnitVolume ' 56 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitVolumeFlowRate ' 57

                Case SolidEdgeFramework.UnitTypeConstants.igUnitScalar ' 58 in UOM, in SEOptions

                Case SolidEdgeFramework.UnitTypeConstants.igUnitTorque ' 59 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitEnergyDensity ' 60 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitPressure ' 61 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatGeneration ' 62 in UOM
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

                Case SolidEdgeFramework.UnitTypeConstants.igUnitTemperatureGradient ' 63 in UOM, in SEOptions
                    For Each item In System.Enum.GetValues(GetType(SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants))
                        OutList.Add(item.ToString)
                    Next

            End Select
        Next

        Dim i = 0

        ' All SolidEdgeConstants.UnitOfMeasure_XXX_ReadoutConstants
        Dim junk As Type
        junk = GetType(SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureForceReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureMassReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureSpecificHeatReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants)
        junk = GetType(SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants)

    End Sub
End Class
