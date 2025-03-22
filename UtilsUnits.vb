Option Strict On

Public Class UtilsUnits

    Public ObjDoc As SolidEdgeFramework.SolidEdgeDocument
    Public IsIPS As Boolean = False
    Public IsMMKS As Boolean = False

    Public Sub New(_objDoc As SolidEdgeFramework.SolidEdgeDocument)
        ObjDoc = _objDoc
        CheckUnitSystem()
    End Sub

    Private Sub CheckUnitSystem()

        ' Checks the length unit setting in the document for 'mm' or 'in' and sets the Unit System accordingly.
        ' The two systems are MMKS (mm, kg, s) or IPS (in, lbm, s)

        Dim UnitsOfMeasure As SolidEdgeFramework.UnitsOfMeasure = ObjDoc.UnitsOfMeasure

        For Each UnitOfMeasure As SolidEdgeFramework.UnitOfMeasure In UnitsOfMeasure
            If UnitOfMeasure.Type = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
                If UnitOfMeasure.Units = SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthInch Then
                    IsIPS = True
                ElseIf UnitOfMeasure.Units = SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthMillimeter Then
                    IsMMKS = True
                End If
            End If
        Next

    End Sub

    Public Function ValueToCad(
        UserValue As Double,
        UnitType As SolidEdgeFramework.UnitTypeConstants
        ) As Double

        ' Converts the units of the variable displayed in the user interface into the units Solid Edge uses internally
        ' Eg, UserValue 'in' -> 'm', UserValue 'kg/mm^3' -> 'kg/m^3'

        Dim CadValue As Double
        Dim CadString As String

        Dim UOM As SolidEdgeFramework.UnitsOfMeasure = ObjDoc.UnitsOfMeasure
        Dim UnitReadout As String = GetUnitReadout(UnitType)
        Dim UserValueString As String = String.Format("{0} {1}", UserValue.ToString, UnitReadout).Trim  ' '2.74' -> '2.74 mm'

        Try
            CadString = UOM.ParseUnit(UnitType, UserValueString).ToString
            CadValue = CDbl(CadString)
        Catch ex As Exception
            CadValue = UserValue
        End Try

        Return CadValue
    End Function

    Public Function CadToValue(
        CadValue As Double,
        UnitType As SolidEdgeFramework.UnitTypeConstants
        ) As Double

        ' Converts the units Solid Edge uses internally into the units of the variable displayed in the user interface
        ' Eg, UserValue 'm' -> 'in', UserValue 'kg/m^3' -> 'kg/mm^3'

        Dim UserValue As Double

        Dim UOM As SolidEdgeFramework.UnitsOfMeasure = ObjDoc.UnitsOfMeasure
        Dim ValueString As String

        Try
            ValueString = CStr(UOM.FormatUnit(UnitType, CadValue))
            ValueString = ValueString.Split(CChar(" "))(0).Trim
            UserValue = CDbl(ValueString)
        Catch ex As Exception
            UserValue = CadValue
        End Try

        Return UserValue
    End Function

    Public Function GetUnitReadout(objVar As Object) As String

        ' The unit readout is the text that represents the units of the variable.
        ' Eg, 'mm', 'lbm/in^3', etc.

        Dim UnitReadout As String = ""
        Dim UnitTypeConstant As SolidEdgeFramework.UnitTypeConstants

        ' ###### Not getting the correct UnitTypeConstant for Torque (enum 59) up to Thermal Gradient (enum 63) ######
        ' 20250321 reported to VAR

        Select Case HCComObject.GetCOMObjectType(objVar)
            Case GetType(SolidEdgeFramework.variable)
                Dim tmpVar = CType(objVar, SolidEdgeFramework.variable)
                UnitTypeConstant = CType(tmpVar.UnitsType, SolidEdgeFramework.UnitTypeConstants)
            Case GetType(SolidEdgeFrameworkSupport.Dimension)
                Dim tmpDim = CType(objVar, SolidEdgeFrameworkSupport.Dimension)
                UnitTypeConstant = CType(tmpDim.UnitsType, SolidEdgeFramework.UnitTypeConstants)
            Case Else
                MsgBox(String.Format("Unrecognized variable type '{0}'", objVar.GetType.ToString))
        End Select

        ' These are the offending UnitTypeConstants.  They are handled below.
        'Torque: UnitsType '398'
        'EnergyDensity: UnitsType '541'
        'HeatGeneration: UnitsType '620'
        'TemperatureGradient: UnitsType '609'

        Select Case CInt(UnitTypeConstant)
            Case 398
                UnitTypeConstant = SolidEdgeFramework.UnitTypeConstants.igUnitTorque
            Case 541
                UnitTypeConstant = SolidEdgeFramework.UnitTypeConstants.igUnitEnergyDensity
            Case 620
                UnitTypeConstant = SolidEdgeFramework.UnitTypeConstants.igUnitHeatGeneration
            Case 609
                UnitTypeConstant = SolidEdgeFramework.UnitTypeConstants.igUnitTemperatureGradient
        End Select

        UnitReadout = GetUnitReadout(UnitTypeConstant)

        Return UnitReadout
    End Function

    Private Function GetUnitReadout(_UnitTypeConstant As SolidEdgeFramework.UnitTypeConstants) As String
        Dim UnitReadout As String = ""

        Dim UnitsOfMeasure As SolidEdgeFramework.UnitsOfMeasure = ObjDoc.UnitsOfMeasure
        Dim UnitOfMeasure As SolidEdgeFramework.UnitOfMeasure = Nothing

        For Each UnitOfMeasure In UnitsOfMeasure
            If UnitOfMeasure.Type = _UnitTypeConstant Then Exit For
        Next

        If UnitOfMeasure Is Nothing Then Return ""

        Select Case _UnitTypeConstant

            Case SolidEdgeFramework.UnitTypeConstants.igUnitDistance ' 1 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthInch
                        UnitReadout = "in"
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthFoot
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthInchAbbr
                        UnitReadout = "in"
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthFootAbbr
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthFootInch
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthFootInchAbbr
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthYard
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthMile
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthTenth
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthHundredth
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthThousandth
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthRod
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthPole
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthChain
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthFurlong
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthMeter
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthCentimeter
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthMillimeter
                        UnitReadout = "mm"
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthKilometer
                    Case SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthNanometer
                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitAngle ' 2 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleRadian
                        UnitReadout = "rad"
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleDegree
                        UnitReadout = "°"
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleMinute
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleSecond
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleGradient
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleDegreeMinuteSecond
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleDegreeAbbr
                        UnitReadout = "°"
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleMinuteAbbr
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleSecondAbbr
                    Case SolidEdgeConstants.UnitOfMeasureAngleReadoutConstants.seAngleDegreeMinuteSecondAbbr
                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitMass ' 3 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassSlug
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassSlinch
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassPoundMass
                        UnitReadout = "lbm"
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassTon
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassNetTon
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassKilogram
                        UnitReadout = "kg"
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassGram
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassMegagram
                    Case SolidEdgeConstants.UnitOfMeasureMassReadoutConstants.seMassTonne
                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitTime ' 4, in SEOptions
                UnitReadout = "s"

            Case SolidEdgeFramework.UnitTypeConstants.igUnitTemperature ' 5 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants.seKelvin
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants.seCelcius
                        UnitReadout = "C"
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants.seRankine
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureReadoutConstants.seFahrenheit
                        UnitReadout = "F"
                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricCharge ' 6
            Case SolidEdgeFramework.UnitTypeConstants.igUnitLuminousIntensity ' 7
            Case SolidEdgeFramework.UnitTypeConstants.igUnitAmountOfSubstance ' 8
            Case SolidEdgeFramework.UnitTypeConstants.igUnitSolidAngle ' 9

            Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularAcceleration ' 10 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.seradpersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.seradperminutesq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.seradperhoursq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.sedegpersecondsq
                        UnitReadout = "deg/s^2"
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.sedegperminutesq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.sedegperhoursq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.seHertzpersecond
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.serevolutionperminutesq
                    Case SolidEdgeConstants.UnitOfMeasureAngularAccelerationReadoutConstants.serevolutionperhoursq

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularMomentum ' 11

            Case SolidEdgeFramework.UnitTypeConstants.igUnitAngularVelocity ' 12 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seRadianPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seRadianPerMinute
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seRadianPerHour
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seCyclePerSecond
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seCyclePerMinute
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seCyclePerHour
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seDegreePerSecond
                        UnitReadout = "deg/s"
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seDegreePerMinute
                    Case SolidEdgeConstants.UnitOfMeasureAngularVelocityReadoutConstants.seDegreePerHour

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitArea ' 13 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaInchSquared
                        UnitReadout = "in^2"
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaFootSquared
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaYardSquared
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaMileSquared
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaAcre
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaMeterSquared
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaCentimeterSquared
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaMillimeterSquared
                        UnitReadout = "mm^2"
                    Case SolidEdgeConstants.UnitOfMeasureAreaReadoutConstants.seAreaKilometerSquared

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitBodyForce ' 14

            Case SolidEdgeFramework.UnitTypeConstants.igUnitCoefficientOfThermalExpansion ' 15 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants.sePerFahrenheit
                        UnitReadout = "/F"
                    Case SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants.sePerKelvin
                    Case SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants.sePerRankine
                    Case SolidEdgeConstants.UnitOfMeasureCoefOfThermalExpansionReadoutConstants.sePerCelsius
                        UnitReadout = "/C"

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitDensity ' 16 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityPoundMassPerFootCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityPoundMassPerInchCubed
                        UnitReadout = "lbm/in^3"
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensitySlugPerFootCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensitySlinchPerFootCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityKilogramPerMeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityKilogramPerDecimeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityKilogramPerCentimeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityKilogramPerMillimeterCubed
                        UnitReadout = "kg/mm^3"
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityKilogramPerLiter
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityGramPerMeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityGramPerDecimeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityGramPerCentimeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureDensityReadoutConstants.seDensityGramPerMillimeterCubed

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalCapacitance ' 17
            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalConductance ' 18
            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalFieldStrength ' 19
            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalInductance ' 20
            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalPotential ' 21
            Case SolidEdgeFramework.UnitTypeConstants.igUnitElectricalResistance ' 22

            Case SolidEdgeFramework.UnitTypeConstants.igUnitEnergy ' 23 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyJoule
                        UnitReadout = "J"
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergycentijoule
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergymillijoule
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergymicrojoule
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergykilojoule
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyWattsecond
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyWatthour
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergykilowatthour
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyergs
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyelectronVolt
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyinchespoundforce
                        UnitReadout = "in-lbf"
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyfootpoundforce
                    Case SolidEdgeConstants.UnitOfMeasureEnergyReadoutConstants.seEnergyBritishThermalUnit

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitEntropy ' 24

            Case SolidEdgeFramework.UnitTypeConstants.igUnitFilmCoefficient ' 25 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seWattsPerSqMeterKelvin
                        UnitReadout = "W/m^2-K"
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seKiloWattsPerSqMeterKelvin
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seWattsPerSqCentiMeterKelvin
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seWattsPerSqMeterCelcious
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seBTUPerSqFootHourFahrenheit
                        UnitReadout = "BTU/hr-ft^2F"
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seBTUPerSqInchHourFahrenheit
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seBTUPerSqFootHourRankine
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seBTUPerSqInchHourRankine
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seFootPoundForcePerSecondSqFootFahrenheit
                    Case SolidEdgeConstants.UnitOfMeasureHeatTransferCoefficientReadoutConstants.seInchPoundForcePerSecondSqInchtFahrenheit

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitForce ' 26 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceNewton
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceNanoNewton
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceMilliNewton
                        UnitReadout = "mN"
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceKiloNewton
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForcePoundForce
                        UnitReadout = "lbf"
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceDyne
                    Case SolidEdgeConstants.UnitOfMeasureForceReadoutConstants.seForceKip

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitForcePerArea ' 27 in UOM
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaPascal
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaMilliPascal
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaKiloPascal
                        UnitReadout = "kPa"
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaKiloNewton
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaMegaPascal
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaPoundForcePerSqInch
                        UnitReadout = "psi"
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaKipPerSqInch
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaPoundForcePerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaBar
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaMilliBar
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaAtmosphere
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaNewtonPerSqMillimeter
                    Case SolidEdgeConstants.UnitOfMeasureForcePerAreaReadoutConstants.seForcePerAreaKipPerSqFoot

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitForcePerDistance ' 28

            Case SolidEdgeFramework.UnitTypeConstants.igUnitFrequency ' 29 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants.seFrequencyPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants.seFrequencyPerMinute
                    Case SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants.seFrequencyPerHour
                    Case SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants.seFrequencyHertz
                        UnitReadout = "Hz"
                    Case SolidEdgeConstants.UnitOfMeasureFrequencyReadoutConstants.seFrequencyMegaHertz

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatCapacity ' 30 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureSpecificHeatReadoutConstants.seBTUPerPoundFahrenheit
                        UnitReadout = "BTU/lbm-F"
                    Case SolidEdgeConstants.UnitOfMeasureSpecificHeatReadoutConstants.seJoulePerKilogramKelvin
                    Case SolidEdgeConstants.UnitOfMeasureSpecificHeatReadoutConstants.seJoulePerKilogramCelsius
                        UnitReadout = "J/kg-C"

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatFluxPerArea ' 31 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seWattsPerSqMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seKiloWattPerSqMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seWattsPerSqCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seWattsPerSqMilliMeter
                        UnitReadout = "W/mm^2"
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seWattsPerSqInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seWattsPerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seCaloriePerSecondSqMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seHorsePowerPerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seFootPoundForcePerSecondSqFoot
                        UnitReadout = "ft-lbf/s-ft^2"
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seFootPoundForcePerSecondSqInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seInchPoundForcePerSecondSqInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seInchPoundForcePerSecondSqFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seBTUPerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxReadoutConstants.seBTUPerSqInch

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatFluxPerDistance ' 32 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seWattsPerMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seKiloWattPerMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seWattsPerCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seWattsPerMilliMeter
                        UnitReadout = "W/mm"
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seWattsPerInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seWattsPerFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seCaloriePerSecondMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seHorsePowerPerFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seFootPoundForcePerSecondFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seFootPoundForcePerSecondInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seBTUPerHrFoot
                        UnitReadout = "BTU/hr-ft"
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seBTUPerHrInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seInchPoundForcePerSecondInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatFluxPerDistanceReadoutConstants.seInchPoundForcePerSecondFoot

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatSource ' 33
            Case SolidEdgeFramework.UnitTypeConstants.igUnitIlluminance ' 34

            Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearAcceleration ' 35 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.semillimeterspersecondsq
                        UnitReadout = "mm/s^2"
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.secentimeterspersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.semeterspersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.sekilometerspersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.sekilometersperhoursq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.seinchespersecondsq
                        UnitReadout = "in/s^2"
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.sefeetpersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.semilespersecondsq
                    Case SolidEdgeConstants.UnitOfMeasureLinearAccelerationReadoutConstants.semilesperhoursq

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearPerAngular ' 36

            Case SolidEdgeFramework.UnitTypeConstants.igUnitLinearVelocity ' 37 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seMillimeterPerSecond
                        UnitReadout = "mm/s"
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seCentimeterPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seMeterPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seKilometerPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seKilometerPerHour
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seInchPerSecond
                        UnitReadout = "in/s"
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seFootPerSecond
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seMilePerSecond
                    Case SolidEdgeConstants.UnitOfMeasureLinearVelocityReadoutConstants.seMilePerHour

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitLuminousFlux ' 38
            Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFieldStrength ' 39
            Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFlux ' 40
            Case SolidEdgeFramework.UnitTypeConstants.igUnitMagneticFluxDensity ' 41
            Case SolidEdgeFramework.UnitTypeConstants.igUnitMassFlowRate ' 42

            Case SolidEdgeFramework.UnitTypeConstants.igUnitMassMomentOfInertia ' 43
                If IsIPS Then UnitReadout = "lbm-in^2"
                If IsMMKS Then UnitReadout = "kg-mm^2"

            Case SolidEdgeFramework.UnitTypeConstants.igUnitMassPerArea ' 44

            Case SolidEdgeFramework.UnitTypeConstants.igUnitMassPerLength ' 45 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seSlugPerInch
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seSlugPerFoot
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seSlinchPerInch
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.sePoundPerInch
                        UnitReadout = "lbm/in"
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.sePoundPerFoot
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seKilogramPerMeter
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seKilogramPerMillimeter
                        UnitReadout = "kg/mm"
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seGramPerMillimeter
                    Case SolidEdgeConstants.UnitOfMeasureLinearDensityReadoutConstants.seGramPerCentimeter

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitMomentum ' 46
            Case SolidEdgeFramework.UnitTypeConstants.igUnitPerDistance ' 47

            Case SolidEdgeFramework.UnitTypeConstants.igUnitPower ' 48 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seWatt
                        UnitReadout = "W"
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seMilliWatt
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seKiloWatt
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seMegaWatt
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seErgPerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seCaloriePerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seHorsePower
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seNewtonMeterPerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seJoulePerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seVoltAmpere
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seFootPoundForcePerSecond
                        UnitReadout = "ft-lbf/s"
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seFootPoundForcePerMinute
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seFootPoundForcePerHour
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seInchPoundForcePerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seInchPoundForcePerMinute
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seInchPoundForcePerHour
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seBTUPerSecond
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seBTUPerMinute
                    Case SolidEdgeConstants.UnitOfMeasurePowerReadoutConstants.seBTUPerHour

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitQuantityOfElectricity ' 49
            Case SolidEdgeFramework.UnitTypeConstants.igUnitRadiantIntensity ' 50
            Case SolidEdgeFramework.UnitTypeConstants.igUnitRotationalStiffness ' 51
            Case SolidEdgeFramework.UnitTypeConstants.igUnitSecondMomentOfArea ' 52

            Case SolidEdgeFramework.UnitTypeConstants.igUnitThermalConductivity ' 53 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants.seBTUPerHourFootFahrenheit
                        UnitReadout = "BTU/hr-ft-F"
                    Case SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants.seInchPoundForcePerSecondInchFarhrenheit
                    Case SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants.seWattPerMeterCelsius
                    Case SolidEdgeConstants.UnitOfMeasureThermalConductivityReadoutConstants.seKiloWattPerMeterCelsius
                        UnitReadout = "kW/m-C"

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitDynamicViscosity ' 54
            Case SolidEdgeFramework.UnitTypeConstants.igUnitKinematicViscosity ' 55

            Case SolidEdgeFramework.UnitTypeConstants.igUnitVolume ' 56 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeInchCubed
                        UnitReadout = "in^3"
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeFootCubed
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeYardCubed
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeGallon
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeQuart
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumePint
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeOunce
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeMiterCubed
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeCentimeterCubed
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeMillimeterCubed
                        UnitReadout = "mm^3"
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeLiter
                    Case SolidEdgeConstants.UnitOfMeasureVolumeReadoutConstants.seVolumeDecimeterCubed

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitVolumeFlowRate ' 57

            Case SolidEdgeFramework.UnitTypeConstants.igUnitScalar ' 58 in UOM, in SEOptions
                UnitReadout = ""

            Case SolidEdgeFramework.UnitTypeConstants.igUnitTorque ' 59 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seNewtonMeter
                        UnitReadout = "N-m"
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seNewtonMiliMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seNewtonCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloNewtonMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seDynesMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seDynesMilliMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seDynesCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seInchesPoundForce
                        UnitReadout = "in-lbf"
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seFootPoundForce
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKipsInches
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKipsFoot
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloGramMeterForce
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloGramMilliMeterForce
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloGramCentiMeterForce
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloNewtonMilliMeter
                    Case SolidEdgeConstants.UnitOfMeasureTorqueReadoutConstants.seKiloNewtonCentiMeter

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitEnergyDensity ' 60 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seJoulepermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.secentijoulepercentimetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.semillijoulepermillimetercu
                        UnitReadout = "mJ/mm^3"
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.semicrojoulepermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.sekilojoulepermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seWattsecondpermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seWatthourpermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.sekilowatthourpermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seergspermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seelectronVoltpermetercu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seinchespoundforceperinchcu
                        UnitReadout = "in-lbf/in^3"
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.sefootpoundforceperfootcu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seBritishThermalUnitperinchcu
                    Case SolidEdgeConstants.UnitOfMeasureEnergyDensityReadoutConstants.seBritishThermalUnitperfootcu

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitPressure ' 61 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressurePascal
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureMilliPascal
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureKiloPascal
                        UnitReadout = "kPa"
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureMegaPascal
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressurePoundForcePerSqInch
                        UnitReadout = "psi"
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureKipPerSqInch
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressurePoundForcePerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureKipPerSqFoot
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureBar
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureMilliBar
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureAtmosphere
                    Case SolidEdgeConstants.UnitOfMeasurePressureReadoutConstants.sePressureNewtonPerSqMillimeter

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitHeatGeneration ' 62 in UOM
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seWattPerCuMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seKiloWattPerCuMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seWattPerCuCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seWattPerCuMilliMeter
                        UnitReadout = "W/mm^3"
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seWattPerCuInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seWattPerCuFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seBTUPerHourCuFoot
                        UnitReadout = "BTU/hr-ft^3"
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seBTUPerHourCuInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seInchPoundForcePerSecondCuInch
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seInchPoundForcePerSecondCuFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seHorsePowerPerCuFoot
                    Case SolidEdgeConstants.UnitOfMeasureHeatGenerationReadoutConstants.seHorsePowerPerCuInch

                End Select

            Case SolidEdgeFramework.UnitTypeConstants.igUnitTemperatureGradient ' 63 in UOM, in SEOptions
                Select Case UnitOfMeasure.Units
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seKelvinPerMeter
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seKelvinPerCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seKelvinPerMilliMeter
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seCelciousPerMeter
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seCelciousPerCentiMeter
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seCelciousPerMilliMeter
                        UnitReadout = "C/mm"
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seFahrenheitPerFoot
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seFahrenheitPerInch
                        UnitReadout = "F/in"
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seRankinePerFoot
                    Case SolidEdgeConstants.UnitOfMeasureTemperatureGradientReadoutConstants.seRankinePerInch

                End Select

            Case Else
                MsgBox(String.Format("Unrecognized unit type constant '{0}'", _UnitTypeConstant.ToString))

        End Select

        Return UnitReadout
    End Function

    Public Sub ListUOMs()
        ' Stress in SEOptions, not Constants.UnitsOfMeasure or Document.UOM
        Dim OutList As New List(Of String)

        For Each UnitTypeConstant As SolidEdgeFramework.UnitTypeConstants In System.Enum.GetValues(GetType(SolidEdgeFramework.UnitTypeConstants))

            OutList.Add("")
            OutList.Add(UnitTypeConstant.ToString)

            Select Case UnitTypeConstant
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

    End Sub
End Class
