import { test, expect } from '@playwright/test';

test('basic test', async ({ page }) => {
  await page.goto('/');
  await page.waitForSelector('header');
  await expect(page.locator('header div:has-text("About")')).toBeDefined();
})
