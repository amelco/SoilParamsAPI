# SoilParamsAPI

REST API that calculates soil hydraulic parameters.

Uses swagger to show the endpoints.

Example POST input:
```json
{
  "title": "Titulo",
  "description": "Descrição",
  "pressureHeads": [
    5, 10, 100, 500, 1000, 10000, 15000
  ],
  "measuredWaterContents": [
    0.49, 0.45, 0.38, 0.33, 0.30, 0.28, 0.27
  ],
  "model": "VG",
  "initialGuess": [
    0.2, 0.5, 1.2, 0.5
  ]
}
```
