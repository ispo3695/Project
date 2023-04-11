

/* USER CODE BEGIN 0 */

#include "main.h"
#include "stm32f1xx_it.h"
#include "GPIO.h"
#include "UART.h"
#include "TIM.h"


extern ADC_HandleTypeDef hadc1;
extern TIM_HandleTypeDef htim2;
extern TIM_HandleTypeDef htim4;

extern UART_HandleTypeDef huart1;
extern UART_HandleTypeDef huart3;
/* USER CODE END 0 */



/* USER CODE BEGIN 1 */



void NMI_Handler(void)
{

}


void HardFault_Handler(void)
{

	while (1)
	{
	}
}

void MemManage_Handler(void)
{

	while (1)
	{

	}
}


void BusFault_Handler(void)
{

	while (1)
	{

	}
}


void UsageFault_Handler(void)
{

	while (1)
	{

	}
}


void SVC_Handler(void)
{

}


void DebugMon_Handler(void)
{

}


void PendSV_Handler(void)
{

}


void SysTick_Handler(void)
{

	HAL_IncTick();

}

void RCC_IRQHandler(void)
{


}




void TIM2_IRQHandler(void)
{
	HAL_TIM_IRQHandler(&htim2);

}
void TIM4_IRQHandler(void)
{

	HAL_TIM_IRQHandler(&htim4);

}


/* USER CODE END 1 */

/* USER CODE BEGIN 2 */

void EXTI15_10_IRQHandler(void)
{


	HAL_GPIO_EXTI_IRQHandler(SW4_PIN);

}
void EXTI9_5_IRQHandler(void)
{


	HAL_GPIO_EXTI_IRQHandler(SW1_PIN);

}
void EXTI0_IRQHandler(void)
{


	HAL_GPIO_EXTI_IRQHandler(SW2_PIN);

}
void EXTI1_IRQHandler(void)
{


	HAL_GPIO_EXTI_IRQHandler(SW3_PIN);

}




void USART1_IRQHandler(void)
{

	HAL_UART_IRQHandler(&huart1);

}
void USART3_IRQHandler(void)
{

	HAL_UART_IRQHandler(&huart3);

}
/* USER CODE END 2 */

