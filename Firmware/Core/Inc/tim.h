#include "stm32f1xx_hal.h"



#define MAX_PWM_RESOLUTION 10

#define EN0_GPIO_Port GPIOA
#define EN0_PIN GPIO_PIN_3

#define EN1_GPIO_Port GPIOA
#define EN1_PIN GPIO_PIN_2


#define EN2_GPIO_Port GPIOA
#define EN2_PIN GPIO_PIN_15


#define EN3_GPIO_Port GPIOB
#define EN3_PIN GPIO_PIN_3


#define EN0(x) x ? HAL_GPIO_WritePin(EN0_GPIO_PORT, EN0_PIN, GPIO_PIN_SET) :	   HAL_GPIO_WritePin(EN0_GPIO_PORT, EN0_PIN, GPIO_PIN_RESET)
#define EN1(x) x ? HAL_GPIO_WritePin(EN1_GPIO_PORT, EN1_PIN, GPIO_PIN_SET) :	    HAL_GPIO_WritePin(EN1_GPIO_PORT, EN1_PIN, GPIO_PIN_RESET)
#define EN2(x) x ? HAL_GPIO_WritePin(EN2_GPIO_PORT, EN2_PIN, GPIO_PIN_SET) :		HAL_GPIO_WritePin(EN2_GPIO_PORT, EN2_PIN, GPIO_PIN_RESET)
#define EN3(x) x ? HAL_GPIO_WritePin(EN3_GPIO_PORT, EN3_PIN, GPIO_PIN_SET) :		HAL_GPIO_WritePin(EN3_GPIO_PORT, EN3_PIN, GPIO_PIN_RESET)





void MX_TIM2_Init(uint16_t , uint16_t , uint16_t );
void analgoWrite(uint8_t duty );
void analgoWrite_ch1(uint8_t duty );
void analgoWrite_ch2(uint8_t duty );
void analgoWrite_ch3(uint8_t duty );
void analgoWrite_ch4(uint8_t duty );




